using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

	public float mousSensitivity;
	public Transform playerBoddy;

	float xAxisClamp= 0f;

	void Awake(){
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.L) && Cursor.lockState == CursorLockMode.Locked) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		} else if (Input.GetKeyDown (KeyCode.L) && Cursor.lockState == CursorLockMode.None) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");

		float rotAmountX = mouseX * mousSensitivity;
		float rotAmountY = mouseY * mousSensitivity;

		xAxisClamp -= rotAmountY;

		Vector3 targetRotCam = transform.rotation.eulerAngles;
		Vector3 targetRotBody = playerBoddy.rotation.eulerAngles;

		targetRotCam.x -= rotAmountY;
		targetRotCam.z = 0;
		targetRotBody.y += rotAmountX;

		if (xAxisClamp > 90) {
			xAxisClamp = 90;
			targetRotCam.x = 90;
		}
		else if (xAxisClamp < -90) {
			xAxisClamp = -90;
			targetRotCam.x = 270;
		}

		transform.rotation = Quaternion.Euler (targetRotCam);
		playerBoddy.rotation =  Quaternion.Euler (targetRotBody);
	}
		
}
