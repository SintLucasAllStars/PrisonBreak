using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabScape : MonoBehaviour
{
    public GameObject prefab;
    public float minHeight = 0f;
    public float maxHeight = 1f;
    public float gridSize = 10f;
    public float detail = 10f;

    void Start()
    {
        ProceduralManager.instance.SetSeed(10);
        Generate();
    }

    public void Clean()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void Generate()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                //float r = Random.Range(minHeight, maxHeight);

                float perlinX = (x / detail) + ProceduralManager.instance.GetPerlinSeed();
                float perlinY = (z / detail) + ProceduralManager.instance.GetPerlinSeed();

                float r = Mathf.PerlinNoise(x/10.0f, z/10.0f)-minHeight*maxHeight;

                Vector3 pos = new Vector3(x, r, z);
                Instantiate(prefab, transform.position + pos, Quaternion.identity, transform);
            }
        }
    }

}
    