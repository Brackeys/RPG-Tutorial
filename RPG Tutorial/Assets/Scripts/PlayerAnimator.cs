using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

	public Animator animator;
	PlayerMotor motor;

	void Start() {
		motor = GetComponent<PlayerMotor> ();
	}

	void Update () {
		animator.SetFloat ("Speed Percent", motor.currentSpeed/motor.maxSpeed,.1f,Time.deltaTime);
	}
}
