using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour {

	public static GameBehaviour gb;
	public static PlayerBehaviour pb;
	public static UnityStandardAssets.Characters.FirstPerson.FirstPersonController fp;
	public static InventoryManager im;

	public enum ItemUses{heal};
	public List<System.Func<int,bool>> itemUses = new List<System.Func<int, bool>>();

	public bool holdLMB = false;
	GameObject loadingBar;
	bool terrainLoaded = false;

	GameObject[] escapeItems;

	void Awake () {
		if (GameBehaviour.gb == null)
			GameBehaviour.gb = this;
		else
			DestroyImmediate (this);
		DontDestroyOnLoad (this);

		loadingBar = GameObject.Find ("Loading");
		loadingBar.SetActive (false);
		escapeItems = new GameObject[]{ Resources.Load<GameObject> ("Item/Crystal"), Resources.Load<GameObject> ("Item/Engine"), Resources.Load<GameObject> ("Item/Raft")};
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Start(){
		fp = pb.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ();
		itemUses.Add(pb.Heal);
	}

	void Update () {
		if (pb.isAlive) {
			if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown (0))
				StartCoroutine (HoldMouseDown ());

			if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyUp (KeyCode.E)) {
				RaycastHit hit;
				if (Physics.Raycast (Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0f)), out hit, 2.2f))
				if (hit.collider.CompareTag ("Interactable"))
					hit.collider.gameObject.GetComponent<IInteractable> ().Interact ();
			}

			if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyUp (KeyCode.L))
				fp.TurnLight ();

			if (pb.gameObject.transform.position.y < 0f && !terrainLoaded)
			if (im.HasAccess (13)) {
				terrainLoaded = true;
				StartCoroutine (LoadMap ());
				fp.Parachute ();
			}else
				EndGame(false);
		}
	}

	public void EndGame(bool winConditionMet){
		Debug.Log (winConditionMet ? "You win" : "You lose");
	}

	IEnumerator HoldMouseDown(){
		float timer = 0f;
		while(!Input.GetMouseButtonUp(0)){
			timer += Time.deltaTime;
			if (!holdLMB && timer > 1f) {
				holdLMB = true;
				//Visual cursor change
			}
			yield return 0;
		}
		holdLMB = false;
	}

	IEnumerator LoadMap(){
		loadingBar.SetActive (true);
		yield return 0;
		GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Terrain/Terrain"));
		go.GetComponent<GenerateTerrain> ().Instantiate (new Vector3 (pb.transform.position.x,pb.transform.position.y - 200f,pb.transform.position.z));
		go.GetComponent<GenerateTerrain> ().SpawnItems (escapeItems);
		loadingBar.SetActive (false);
		yield return 0;
	}
}
