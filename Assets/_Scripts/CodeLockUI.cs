using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLockUI : MonoBehaviour {

	public static CodeLockUI clUI;

	CodeLock cl;
	Text display;

	bool isShowing = true;

	void Start(){
		display = transform.GetChild (0).GetChild (0).GetComponent<Text> ();
		CodeLockUI.clUI = this;
		ShowHideUI ();
	}

	void Update(){
		if (isShowing && Input.GetKeyDown (KeyCode.Escape))
			ShowHideUI ();
	}

	public void ShowHideUI(bool show = false, CodeLock cl = null){
		if (show != isShowing){
			isShowing = show;
			Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
			if (GameBehaviour.fp != null)
				GameBehaviour.fp.SetCanRotate (!show);
			gameObject.GetComponent<Image> ().enabled = show;
			for (int i = 0; i < transform.childCount; i++)
				transform.GetChild (i).gameObject.SetActive (show);
			if (show)
				this.cl = cl;
			else
				this.cl = null;
		}
	}

	public void UpdateDisplay(){if(isShowing) display.text = cl.GetInput ();}

	public void Clear(){cl.ClearCode ();UpdateDisplay ();}
	public void Enter(){cl.EnterCode ();UpdateDisplay ();}
	public void Add(string c){cl.AddCode (c.ToCharArray()[0]);UpdateDisplay ();}
}
