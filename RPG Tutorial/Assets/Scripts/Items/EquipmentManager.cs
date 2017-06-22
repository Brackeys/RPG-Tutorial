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

	public Equipment head;
	public Equipment chest;
	public Equipment legs;
	public Equipment weapon;
	public Equipment shield;

	public delegate void OnItemEquipped(Equipment newItem, Equipment oldItem);
	public OnItemEquipped onItemEquippedCallback;

	Inventory inventory;

	void Start ()
	{
		inventory = Inventory.instance;
	}

	public void Equip (Equipment newItem)
	{
		Equipment oldItem = null;

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

		if (oldItem != null)
		{
			inventory.Add(oldItem);
		}

		if (onItemEquippedCallback != null)
			onItemEquippedCallback.Invoke(newItem, oldItem);

		Debug.Log(newItem.name + " equipped!");
	}

}
