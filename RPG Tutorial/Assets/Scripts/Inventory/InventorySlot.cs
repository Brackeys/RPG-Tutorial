using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour {

	public Image icon;
	public Button removeButton;

	InventoryItem item;

	public void AddItem (InventoryItem newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	public void RemoveItemFromInventory ()
	{
		Inventory.instance.Remove(item);
	}

	public void UseItem ()
	{
		if (item != null)
		{
			Debug.Log("Using item...");
			item.Use();
			RemoveItemFromInventory();
		}
	}

}
