using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {


	public bool isAlive = true;
	int maxHealth = 10;
	int health = 3;

	GameObject lifeUI;

	void Start () {
		GameBehaviour.pb = this;
		lifeUI = GameObject.Find ("Lifepoints");
		InstHP (health);
	}


	void Die(){
		isAlive = false;

	}

	void InstHP (int amount = 1){
		if (amount != 0) {
			if (amount > 0) {
				for (int i = 0; i < amount; i++) {
					GameObject go = Instantiate (Resources.Load<GameObject> ("UI/Image"), lifeUI.transform);
					go.GetComponent<RectTransform> ().sizeDelta = new Vector2 (160f, 200f);
					go.GetComponent<UnityEngine.UI.Image> ().sprite = Resources.Load<Sprite> ("UI/HP");
					go.name = "HP";
				}
			} else
				for (int i = 0; i < amount; i++)
					Destroy (lifeUI.transform.GetChild (i));
		}
	}

	public bool Heal (int health) {
		if (health < 0f) {
			this.health += health;
			if (this.health < 0f) {
				Die ();
				return false;
			}
			InstHP (health);
			return true;
		} else {
			if (this.health + health < maxHealth) {
				this.health += health;
				InstHP (health);
			} else
				return false; 
			return true;
		}
	}
}
