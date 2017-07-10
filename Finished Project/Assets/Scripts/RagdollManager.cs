using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour {

	public GameObject show;
	public GameObject hide;

	public void Setup () {
		RecursiveBoneSearch (transform);
		Destroy (GetComponent<Animator> ());
		show.SetActive (true);
		hide.SetActive (false);
	}

	void RecursiveBoneSearch(Transform t) {
		foreach (Transform tC in t) {
			DoBone (tC);
			RecursiveBoneSearch (tC);
		}
	}

	void DoBone(Transform t) {
		if (t.GetComponent<Rigidbody> ()) {
			t.GetComponent<Rigidbody> ().isKinematic = false;
			t.GetComponent<Collider> ().isTrigger = false;

			if (t.GetComponent<FixedJoint> ()) {
				//t.GetComponent<FixedJoint> ().breakForce = 100;

				//t.GetComponent<FixedJoint> ().breakTorque = 100;
			}
		}
	}

}
