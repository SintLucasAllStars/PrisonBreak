using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ProceduralWorld
{
public enum GenType
    {
        RandomBased,
        PerlinBased
    };

    public float minHeight = 0f;
    public float maxHeight = 1f;
    public int size = 10;
    public float detail = 10f;
    public int seed = 0;
    public GenType type;
    public float[,] heights;

    public ProceduralWorld(float minHeight, int size, float detail, int seed, GenType type)
    {
        Debug.Log("Constructor?");
        this.minHeight = minHeight;
        this.maxHeight = maxHeight;
        this.size = size;
        this.detail = detail;
        this.seed = seed;
        this.type = type;

        heights = new float[size, size];

        Generate();
    }

    public void init()
    {
        heights = new float[size, size];
        Generate();
    }

    public void Generate()
    {
        for (int x = 0; x < heights.GetLength(0); x++)
        {
            for (int z = 0; z < heights.GetLength(1); z++)
            {
                float height = 0;

                switch (type)
                {

                    case GenType.RandomBased:
                        height = UnityEngine.Random.Range(minHeight, maxHeight);
                        break;
                    case GenType.PerlinBased:

                        float perlinX = (x / detail) + ProceduralManager.instance.GetPerlinSeed();
                        float perlinY = (z / detail) + ProceduralManager.instance.GetPerlinSeed();
                        height = Mathf.PerlinNoise(perlinX, perlinY) - minHeight * maxHeight;
                        break;
                    default:
                        break;
                }
                heights[x, z] = height;
            }
        }
        Debug.Log("World generated");
    }
}
