using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
[RequireComponent(typeof(TerrainCollider))]
public class GenerateTerrain : MonoBehaviour {

	int width = 512;
	int height = 512;
	int depth = 50;

	int textureQuality = 4;

	public int seed = 0;
	public float scale = 3f;

	public TerrainType[] regions;
	Terrain terry;

	public void Instantiate (Vector3 position){
		transform.position = new Vector3 (-width / 2, -depth,-height / 2) + position;
		terry = GetComponent<Terrain> ();
		if (terry.terrainData == null) {
			terry.terrainData = new TerrainData ();
			GetComponent<TerrainCollider> ().terrainData = terry.terrainData;
		}
		terry.terrainData = GenerateTerrainData (terry.terrainData);
	}

	TerrainData GenerateTerrainData(TerrainData terryData){
		seed = Random.Range (0,100000);
		terryData.heightmapResolution = width;
		terryData.size = new Vector3 (width, Mathf.FloorToInt(depth * 1.2f), height);
		float[,] noisemap = Noise.GenerateNoiseMap (width, height, seed, scale);
		terryData.SetHeights (0,0,noisemap);

		List<SplatPrototype> protos = new List<SplatPrototype>();
		for (int i = 0; i < regions.Length;i++){
			protos.Add(new SplatPrototype());
			protos[i].texture = regions[i].texture;
			protos[i].tileOffset = Vector2.zero;
			protos[i].texture.Apply (true);
		}
		terryData.splatPrototypes = protos.ToArray ();
		terryData.alphamapResolution = width* textureQuality;
		terryData.SetAlphamaps(0,0,NoiseMapToTexture2D.NoiseMapToAlphaMap(this, noisemap, textureQuality));

		return terryData;
	}

	public void SpawnItems(GameObject[] spawnables){
		foreach (GameObject go in spawnables){
			float terrainposX = Random.Range(width*0.1f, width*0.9f);
			float terrainposZ = Random.Range(height*0.1f, height*0.9f);
			Vector3 position = new Vector3(transform.position.x + terrainposX, 0f, transform.position.z + terrainposZ);
			position.y = transform.position.y + terry.SampleHeight (position);
			Vector3 normal = terry.terrainData.GetInterpolatedNormal (terrainposX / width, terrainposZ / height);
			Quaternion rot = Quaternion.LookRotation (normal);
			GameObject instance = GameObject.Instantiate (go, position /*+ (go.transform.lossyScale * 0.45f)*/, rot);
			instance.name = go.name;

			instance.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		}
	}
}

[System.Serializable]
public struct TerrainType{
	public string name;
	public float height;
	public Color color;
	public Texture2D texture;
}