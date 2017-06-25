using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

	public Animator animator;
	PlayerMotor motor;

	void Awake() {
		EquipmentManager.instance.onItemEquippedCallback += OnItemEquiped;
	}

	void Start() {
		motor = GetComponent<PlayerMotor> ();
	}

	void Update () {
		animator.SetFloat ("Speed Percent", motor.currentSpeed/motor.maxSpeed,.1f,Time.deltaTime);
	}

	void OnItemEquiped(Equipment newItem, Equipment oldItem) {

		if (oldItem != null) {
			if (oldItem.equipSlot == EquipmentSlot.Weapon) {
				animator.SetLayerWeight (1, 0); // right hand grip full weight
			}
			if (oldItem.equipSlot == EquipmentSlot.Shield) {
				animator.SetLayerWeight (2, 0); // left hand grip full weight
			}
		}

		if (newItem != null) {
			if (newItem.equipSlot == EquipmentSlot.Weapon) {
				print ("wep weighting");
				animator.SetLayerWeight (1, 1); // right hand grip full weight
			}
			if (newItem.equipSlot == EquipmentSlot.Shield) {
				animator.SetLayerWeight (2, 1); // left hand grip full weight
			}
		}
	}
}
