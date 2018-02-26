using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Joke : MonoBehaviour {

	public Text textObject;

	[Serializable]
	class JsonJoke
	{
		public int id;
		public string joke;

		public JsonJoke()
		{
			id = 0;
			joke = "";
		}
	}
	
	[Serializable]
	class JsonResponse
	{
		public string type;
		public JsonJoke value;

		public JsonResponse()
		{
			value = new JsonJoke();
		}
	}

	string joke;
	string URL = "http://api.icndb.com/jokes/random?limitTo=[nerdy]";


	// Use this for initialization
	IEnumerator Start () {

		WWW request = new WWW(URL);
		yield return request;
		string json = request.text;
		Debug.Log(json);

		JsonResponse res = JsonUtility.FromJson<JsonResponse>(json);



		joke = res.value.joke;

		textObject.text = joke;
		Debug.Log(joke);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

