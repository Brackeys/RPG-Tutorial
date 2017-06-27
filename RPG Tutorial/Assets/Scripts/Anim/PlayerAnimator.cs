using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator {

	void Awake() {
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	protected override void Start() {
		base.Start ();
	}
		

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem) {

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
