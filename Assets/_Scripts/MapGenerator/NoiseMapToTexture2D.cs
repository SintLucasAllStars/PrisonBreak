using System.Collections.Generic;
using UnityEngine;

public static class NoiseMapToTexture2D {

	public static Texture2D DrawNoiseMap(GenerateTerrain genterry, float [,] baseNoisemap,int textureQuality){
//		GenerateTerrain genterry = GameObject.Find ("Terrain").GetComponent<GenerateTerrain> ();
		int width = baseNoisemap.GetLength (0) * textureQuality;
		int height = baseNoisemap.GetLength(0) * textureQuality;
		float[,] noisemap = Noise.GenerateNoiseMap(width, height, genterry.seed, Mathf.Clamp(genterry.scale*textureQuality,16,2048));

		Texture2D ret = new Texture2D(width, height);

		Color[] colorMap = new Color[width * height];
		for (int y = 0; y < height; y++)
			for (int x = 0; x < width; x++)
				colorMap [y * width + x] = Color.Lerp(Color.black, Color.white, noisemap[x,y]);
		ret.filterMode = FilterMode.Point;
		ret.wrapMode = TextureWrapMode.Repeat;
		ret.SetPixels (colorMap);
		ret.Apply ();
		return ret;
	}

	public static Texture2D ColorNoiseMap(GenerateTerrain genterry, float[,] baseNoisemap, int textureQuality){
//		GenerateTerrain genterry = GameObject.Find ("Terrain").GetComponent<GenerateTerrain> ();
		int width = baseNoisemap.GetLength (0) * textureQuality;
		int height = baseNoisemap.GetLength(0) * textureQuality;
		float[,] noisemap = Noise.GenerateNoiseMap(width, height, genterry.seed, Mathf.Clamp(genterry.scale*textureQuality,16,2048));

		Texture2D ret = new Texture2D(width, height);

		Color[] colormap = new Color[height * width ];
		for (int x = 0; x < width; x++) 
			for (int y = 0; y < height; y++)
				colormap [(width - x - 1) * width + y] = GetColorByHeight(genterry, noisemap [x, y]);
		ret.filterMode = FilterMode.Bilinear;
		ret.wrapMode = TextureWrapMode.Repeat;
		ret.SetPixels (colormap);
		ret.Apply ();

		return ret;
	}

	static Color GetColorByHeight(GenerateTerrain genterry, float height){
		for (int i = 0; i < genterry.regions.Length; i++)
			if (height <= genterry.regions [i].height) {
				Color ret = Color.Lerp (genterry.regions [(i - 1) < 0 ? 0 : i - 1].color, genterry.regions [i].color, Mathf.InverseLerp (genterry.regions [(i - 1) < 0 ? 0 : i - 1].height, genterry.regions [i].height, height));
				return ret;
			}
		return Color.red;
	}

	public static float[,,] NoiseMapToAlphaMap(GenerateTerrain genterry, float[,] baseNoisemap, int textureQuality){
		int width = baseNoisemap.GetLength (0) * textureQuality;
		int height = baseNoisemap.GetLength(0) * textureQuality;
		float[,] noisemap = Noise.GenerateNoiseMap(width, height, genterry.seed, Mathf.Clamp(genterry.scale*textureQuality,16,2048));

		float[,,] ret = new float[noisemap.GetLength (0), noisemap.GetLength (1), genterry.regions.GetLength (0)];
		for (int x = 0; x < noisemap.GetLength (0); x++) {
			for (int y = 0; y < noisemap.GetLength (1); y++) {
				bool textureSet = false;
				for (int i = 0; i < genterry.regions.GetLength (0); i++) {
					if (noisemap [x, y] <= genterry.regions [i].height && !textureSet) {
						if (i != 0) {
							float alpha = Mathf.InverseLerp (genterry.regions [i - 1].height, genterry.regions [i].height, noisemap [x, y]);
							ret [x, y, i] = alpha;
							ret [x, y, i - 1] = 1f - alpha;
							textureSet = true;
						} else
							ret [x, y, i] = 0f;
					} else
						ret [x, y, i] = 0f;
				}
			}
		}
		return ret;
	}
}
