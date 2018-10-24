using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxImage : MonoBehaviour, IInteractable {

//    int watched = 0;
    bool loading;
	GameObject overlay;
	Renderer rend;
	Material load;

    void Start() {
		rend = GetComponent<Renderer> ();
		load = Resources.Load<Material>("Sprites/Materials/Loading");	
		overlay = transform.GetChild(0).gameObject;
		overlay.SetActive (false);
        StartCoroutine(Image());
    }

	public void Interact(bool instant = false) {
        StartCoroutine(Image());
	}

    IEnumerator Image() {
		if (!loading){
			loading = true;
			rend.material = load;
			overlay.SetActive (false);
			WWW request = new WWW ("https://randomfox.ca/floof/");
			yield return request;
			var resp = SimpleJSON.JSON.Parse (request.text);
			WWW imageRequest = new WWW (resp ["image"]);
			yield return imageRequest;
			rend.material.mainTexture = imageRequest.texture;
			loading = false;
			if (Time.time > 1f && Random.Range (0f, 1f) < 0.3f) 
				overlay.SetActive (true);
        }
    }
}
