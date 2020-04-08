using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralManager : MonoBehaviour
{
    public static ProceduralManager instance;
    private int seed;
    private float perlinSeed;
    public ProceduralWorld world;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        world.Generate();
    }
    void Start()
    {
        Random.InitState(seed: 10);

        for (int i = 0; i < 10; i++)
        {
            float r = Random.Range(1f, 100f);
            Debug.Log(r);
        }
    }

    public void SetSeed(int seed)
    {
        this.seed = seed;
        Random.InitState(seed);
        perlinSeed = Random.Range(-1000000, 1000000);
    }

    public float GetPerlinSeed()
    {
        return perlinSeed;
    }
}
