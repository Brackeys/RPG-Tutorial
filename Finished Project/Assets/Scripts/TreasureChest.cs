using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable {

	Animator animator;

	bool isOpen;
	public Item[] items;

	void Start() {
		animator = GetComponent<Animator> ();
	}

	public override void Interact ()
	{
		base.Interact ();
		if (!isOpen) {
			animator.SetTrigger ("Open");
			StartCoroutine (CollectTreasure ());
		}
	}

	IEnumerator CollectTreasure() {

		isOpen = true;

		yield return new WaitForSeconds (1f);
		print ("Chest opened");
		foreach (Item i in items) {
			Inventory.instance.Add (i);
		}
	}
}
