using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Transform playCam;
	float ySens = 1f;
	float xSens = 1f;
	Vector2 lookBoundary = new Vector2(-45f,45f);

	bool grounded;
	bool sprint = false;
	float stamina = 1f;

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();

		playCam = GetComponentInChildren<Camera>().transform;
		playCam.transform.parent.localEulerAngles = new Vector3 (lookBoundary[0], 0f, 0f);
		playCam.localEulerAngles = new Vector3 (-lookBoundary [0], 0f, 0f);
		Cursor.lockState = CursorLockMode.Locked;
	}

	public IEnumerator MovementUpdate () {
		while (GameBehaviour.pb.isAlive) {
			//sprinting && Stamina-regeneration
			if ((Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) && stamina > 0f) {
				sprint = true;
				if (rb.velocity.magnitude > 0.5f)
					stamina -= 0.35f * Time.deltaTime;
			} else {
				sprint = false;
				stamina = Mathf.Clamp (stamina + (rb.velocity.magnitude < 0.25f ? 0.5f : 0.05f) * Time.deltaTime, 0f, 1f);
			}

			//Movement of the player
			rb.velocity *= 0.75f;
			if (grounded)
				rb.AddForce ((transform.forward * Input.GetAxis ("Vertical") + transform.right * Input.GetAxis ("Horizontal")) * (sprint ? 1f + stamina : 1f) * 7.5f);
			rb.AddForce (-transform.up * (grounded ? 1f : 10f));
		
			//Rotating of the player
			if (Cursor.lockState == CursorLockMode.Locked) {
				transform.Rotate (Vector3.up * Input.GetAxis ("Mouse X") * xSens);

				Vector3 playRot = playCam.localEulerAngles;
				playRot.x = Mathf.Clamp (playRot.x + Input.GetAxis ("Mouse Y") * -ySens, 0f, (lookBoundary [0] < 0f ? -lookBoundary [0] : lookBoundary [0]) + (lookBoundary [1] < 0f ? -lookBoundary [1] : lookBoundary [1]));
				playCam.localEulerAngles = playRot;
			}
			yield return 0;
		}
	}

	public void SetGround(bool g){grounded = g;}
}
