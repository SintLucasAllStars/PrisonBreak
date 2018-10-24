using UnityEngine;

public class GroundDetector : MonoBehaviour {

	PlayerMovement pm;

	void Start () {
		pm = transform.parent.GetComponent<PlayerMovement> ();
	}

	void OnTriggerStay(Collider coll){
		if (!coll.CompareTag ("Player"))
			pm.SetGround (true);
	}
	void OnTriggerExit(Collider coll){
		pm.SetGround (false);
	}
}
