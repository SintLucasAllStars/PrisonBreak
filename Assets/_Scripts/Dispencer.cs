using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispencer : MonoBehaviour, IInteractable {

	public GameObject spawnPrefab;

	public void Interact(bool instant = false){
		bool act = instant;
		if (!act)
			if (GameBehaviour.im.RemInv ("Coin", true)) 
				act = true;
		if (act) {
			GameObject go = Instantiate (spawnPrefab, transform.GetChild (0).position, Quaternion.identity);
			go.name = spawnPrefab.name;
		}
	}
}
