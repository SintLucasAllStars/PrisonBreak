using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager: MonoBehaviour {

	List<Item> Inventory = new List<Item> (){};
	float inventoryWeight = 0f;
	float maxInventoryWeight = 30f;

//	List<Image> itemBar = new List<Image>();
//	Vector2 barSize;

	int select;

	GameObject inv;

	void Start() {
		
		GameBehaviour.im = this;
		inv = GameObject.Find ("Inventory");

//		InstInvBar ();
//		UpdateInvBar ();

		
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Tab))
			SetInvMode (true);
		
		if (Input.GetKeyUp (KeyCode.Tab))
			SetInvMode (false);

//		for (int i = 49; i < 58; i++) //KeyCode Alpha1 to Alpha9
//			if (Input.GetKeyDown ((KeyCode)i) && i - 49 < Inventory.Count)
//				Select (i - 49);

	}

	public bool Use_DropObject(int ID, bool use = true){
		if (Inventory [ID] is Consumable && use)
			return ((Consumable)Inventory [ID]).Use ();
		RemInv(Inventory [ID]);
		return true;
	}

	public void SetInvMode(bool on){
		if (on) {
			inv.SetActive (true);
			UpdateInventory ();
			Cursor.lockState = CursorLockMode.None;
			GameBehaviour.fp.SetCanRotate (false);
		} else {
			inv.SetActive (false);
			Cursor.lockState = CursorLockMode.Locked;
			GameBehaviour.fp.SetCanRotate (true);
		}
	}

//	public void Select (int i = -1)
//	{
//		Deselect ();
//		if (i >= 0) {
//			itemBar [i].rectTransform.sizeDelta = new Vector2(barSize.y, barSize.y);
//			select = i;
//		}
//	}

//	public void Deselect(){
//		itemBar [select].rectTransform.sizeDelta = new Vector2(barSize.y * 0.9f, barSize.y * 0.9f);
//		select = -1;
//	}

	public void SpawnItem(Item it, Vector3 pos = new Vector3()){
		if (pos == Vector3.zero){
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2)), out hit, 3f)) {
				pos = hit.point + hit.normal * 0.1f;
			}
			else 
				pos = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
		}
		GameObject g = Instantiate (Resources.Load<GameObject> ("Item/" + it.GetName()), pos, Quaternion.identity);
		g.name = it.GetName ();
		PickupItem pick = g.GetComponent<PickupItem> ();
		pick.SetItem (it);
	}

	public bool AddInv (Item i) {
		if (inventoryWeight + i.GetWeight () <= maxInventoryWeight) {
			Inventory.Add (i);
			inventoryWeight += i.GetWeight ();
//			UpdateInvBar ();
			return true;
		}
		return false;
	}

	public bool RemInv(Item i, bool destroy = false){
		if (i == null || !Inventory.Contains(i))
			return false;
		if (Inventory.Remove (i) && !destroy)
			SpawnItem (i);
		inventoryWeight -= i.GetWeight ();
		return true;
	}

	public bool RemInv(string i, bool destroy = false){
		Item item = null;
		foreach (Item it in Inventory)
			if (item == null && it.GetName () == i)
				item = it;
		if (item == null)
			return false;
		if (Inventory.Remove (item) && !destroy)
			SpawnItem (item);
		inventoryWeight -= item.GetWeight ();
		return true;
	}

	public void UpdateInventory(){
		for(int i = 0; i<inv.transform.childCount; i++)
			Destroy (inv.transform.GetChild (i).gameObject);
//		List<string> textCache = new List<string>();

		for (int i = 0; i < Inventory.Count; i++) {
//			if (textCache.Contains (Inventory [i].GetName ())) {
//				bool found = false;
//				for (int j = 0; j < inv.transform.childCount && !found; j++) {
//					string[] text = inv.transform.GetChild (j).GetComponent<Text> ().text.Split (' ');
//					if (text[0] == Inventory [i].GetName ()) {
//						inv.transform.GetChild (j).GetComponent<Text> ().text = ; 
//						found = true;
//					}
//				}
//			} else {
//				textCache.Add (Inventory [i].GetName ());
				Text t = Instantiate (Resources.Load<GameObject> ("UI/Text"), inv.transform).GetComponentInChildren<Text> ();
				t.text = Inventory [i].GetName ();
				JustAButton jb = t.transform.parent.gameObject.GetComponent<JustAButton> ();
				jb.SetInventoryID (i);
//			}
		}
	}

	public bool HasAccess(int ID){
		foreach (Item i in Inventory)
			if (i is Access && ((Access)i).GetActivationID () ==ID)
				return true;
		return false;
	}

	/*
	void InstInvBar(){
		GameObject bar = GameObject.Find ("InventoryBar");
		barSize = bar.GetComponent<RectTransform> ().sizeDelta;
		for (int i = 0; i < 9 ; i++) {
			itemBar.Add( Instantiate (Resources.Load<GameObject>("Image"), bar.transform).GetComponent<Image>());
			itemBar [i].name = "InvBar" + i.ToString();
			itemBar [i].rectTransform.localPosition = new Vector3 (barSize.x / 9f * (i + 0.5f) - barSize.x / 2f, 0f, 0f);
			itemBar [i].rectTransform.sizeDelta = new Vector2 (barSize.y * 0.9f, barSize.y * 0.9f);
		}
	}


	void UpdateInvBar(){
		int i = 0;
		foreach(Image img in itemBar){
			if (i < Inventory.Count) {
				img.sprite = Resources.Load<Sprite> ("ItemSprite/" + Inventory [i].GetName ());
				img.color = Color.white;
				i++;
			} else
				img.color = new Color(0f,0f,0f,0f);
		}
	}*/
}