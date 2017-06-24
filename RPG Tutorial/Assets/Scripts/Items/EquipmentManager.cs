using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	#region Singleton

	public static EquipmentManager instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

	// All the slots
	public Equipment head;
	public Equipment chest;
	public Equipment legs;
	public Equipment weapon;
	public Equipment shield;

	// Callback for when an item is equipped
	public delegate void OnItemEquipped(Equipment newItem, Equipment oldItem);
	public OnItemEquipped onItemEquippedCallback;

	Inventory inventory;

	void Start ()
	{
		inventory = Inventory.instance;
	}

	// Equip a new item
	public void Equip (Equipment newItem)
	{
		Equipment oldItem = null;

		// Find out what slot the item fits in
		// and put it there.
		switch (newItem.equipSlot)
		{
			case EquipmentSlot.Head:
				oldItem = head;
				head = newItem;
				break;
			case EquipmentSlot.Chest:
				oldItem = chest;
				chest = newItem;
				break;
			case EquipmentSlot.Legs:
				oldItem = legs;
				legs = newItem;
				break;
			case EquipmentSlot.Weapon:
				oldItem = weapon;
				weapon = newItem;
				break;
			case EquipmentSlot.Shield:
				oldItem = shield;
				shield = newItem;
				break;
		}

		// If there was already an item in the slot
		// make sure to put it back in the inventory
		if (oldItem != null)
		{
			inventory.Add(oldItem);
		}

		// An item has been equipped so we trigger the callback
		if (onItemEquippedCallback != null)
			onItemEquippedCallback.Invoke(newItem, oldItem);

		Debug.Log(newItem.name + " equipped!");
	}

}
