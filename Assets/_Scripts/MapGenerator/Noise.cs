using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise {

	public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves = 4, float persistance = 0.4f, float lacunarity = 1.75f){
		float [,] noisemap = new float[mapWidth,mapHeight];

		System.Random prng = new System.Random (seed);

		Vector2[] octavesOffset = new Vector2[octaves];
		for (int o = 0; o < octaves; o++)
			octavesOffset [o] = new Vector2 (prng.Next (-10000, 10000), prng.Next (-10000, 10000));

		if (scale <= 0f)
			scale = 0.0001f;

		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {

				float amplitude = 1f;
				float frequency = 1f;
				float noiseHeight = 0f;
				for (int i = 0; i < octaves; i++) {
					float xCoord = (float)x / scale * frequency + octavesOffset[i].x;
					float yCoord = (float)y / scale * frequency + octavesOffset[i].y;

					float perlinValue = Mathf.PerlinNoise (xCoord, yCoord) ;
					noiseHeight += perlinValue * amplitude;

					amplitude *= persistance;
					frequency *= lacunarity;
				}
				noisemap [x, y] = noiseHeight;
			}
		}

		Vector2 minmax = GetMinMax (noisemap);

		for (int y = 0; y < mapHeight; y++)
			for (int x = 0; x < mapWidth; x++) 
				noisemap [x, y] = Mathf.InverseLerp (minmax[0], minmax[1], noisemap [x, y]);

		return noisemap;
	}

	static Vector2 GetMinMax(float[,] noisemap){
		float maxNoiseHeight = 0.5f;
		float minNoiseHeight = 0.5f;

		for (int y = 0; y < noisemap.GetLength(0); y++) {
			for (int x = 0; x < noisemap.GetLength(1); x++) {
				if (noisemap [x, y] > maxNoiseHeight)
					maxNoiseHeight = noisemap [x, y];
				if (noisemap [x, y] < minNoiseHeight)
					minNoiseHeight = noisemap [x, y];
			}
		}
		return new Vector2(minNoiseHeight,maxNoiseHeight);
	}

}
