using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour, IInteractable {

	public GameObject[] interactableObjects;
	List<Door> doors  = new List<Door>();

	List<char> codeLine = new List<char>(); 

	void Start(){
		foreach (GameObject go in interactableObjects)
			doors.Add (go.GetComponent<Door> ());
	}

	public void AddCode(char i){
		if (codeLine.Count < 4)
			codeLine.Add(i);
	}

	public void ClearCode(){codeLine = new List<char>();}

	public void EnterCode(){
		if (CheckCodeWithDoors ()) {
			OpenDoors ();
			CodeLockUI.clUI.ShowHideUI ();
		}else
			ClearCode();
	}
	void OpenDoors(){
		foreach (Door d in doors)
			d.Interact (true);
	}

	bool CheckCodeWithDoors(){
		if (codeLine.Count != 4)
			return false;
		char[] doorID = doors [0].GetID ().ToString().ToCharArray();
		for(int i = 0;i < codeLine.Count;i++)
			if(codeLine[i] != doorID[i])
				return false;
		return true;
	}

	public void Interact(bool instant = false){
		CodeLockUI.clUI.ShowHideUI (true, this);
	}

	public string GetInput(){
		string ret = "";
		foreach (char c in codeLine)
			ret += c; 
		return ret;
	}

}
