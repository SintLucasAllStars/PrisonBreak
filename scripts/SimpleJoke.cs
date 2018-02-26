using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class SimpleJoke : MonoBehaviour {

	string joke;
	public Text textObject;
	string URL = "http://api.icndb.com/jokes/random?limitTo=[nerdy]";

	IEnumerator Start () {

		WWW request = new WWW(URL);
		yield return request;
		string json = request.text;
		Debug.Log(json);

		var response = JSON.Parse(json);

		joke = response["value"]["joke"].Value;
		textObject.text = joke;

		Debug.Log(joke);
	}
}
