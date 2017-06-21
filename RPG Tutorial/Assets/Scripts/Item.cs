using UnityEngine;

public class Item : Interactable {

	public override void Interact()
	{
		base.Interact();

		PickUp();
	}

	void PickUp ()
	{
		Debug.Log("Picking up item...");
	}

}
