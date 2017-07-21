using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour {

	public Image icon;			// Reference to the Icon image
	public Button removeButton;	// Reference to the remove button

	Item item;  // Current item in the slot

	// Add item to the slot
	public void AddItem (Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	// Clear the slot
	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	// Called when the remove button is pressed
	public void OnRemoveButton ()
	{
		Inventory.instance.Remove(item);
	}

	// Called when the item is pressed
	public void UseItem ()
	{
		if (item != null)
		{
			item.Use();
		}
	}

}
