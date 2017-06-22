using UnityEngine;

public class Item : Interactable {

	public InventoryItem item;	// Item to put in the inventory if picked up

	// When the player interacts with the player
	public override void Interact()
	{
		base.Interact();

		PickUp();
	}

	// Pick up the item
	void PickUp ()
	{
		Debug.Log("Picking up " + item.name);
		Inventory.instance.Add(item);	// Add to inventory

		Destroy(gameObject);	// Destroy item from scene
	}

}
