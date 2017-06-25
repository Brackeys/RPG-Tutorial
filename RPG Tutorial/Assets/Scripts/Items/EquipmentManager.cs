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

	public Equipment[] defaultWear;

	Equipment[] currentEquipment;
	SkinnedMeshRenderer[] currentMeshes;

	public SkinnedMeshRenderer targetMesh;

	// Callback for when an item is equipped
	public delegate void OnItemEquipped(Equipment newItem, Equipment oldItem);
	public OnItemEquipped onItemEquippedCallback;

	Inventory inventory;

	void Start ()
	{
		inventory = Inventory.instance;

		int numSlots = System.Enum.GetNames (typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numSlots];
		currentMeshes = new SkinnedMeshRenderer[numSlots];

		foreach (Equipment e in defaultWear) {
			Equip (e);
		}
	}

	// Equip a new item
	public void Equip (Equipment newItem)
	{
		Equipment oldItem = null;

		// Find out what slot the item fits in
		// and put it there.
		int slotIndex = (int)newItem.equipSlot;

		// If there was already an item in the slot
		// make sure to put it back in the inventory
		if (currentEquipment[slotIndex] != null)
		{
			inventory.Add(oldItem);
		}

		// An item has been equipped so we trigger the callback
		if (onItemEquippedCallback != null)
			onItemEquippedCallback.Invoke(newItem, oldItem);

		Debug.Log(newItem.name + " equipped!");

		AttachToMesh (newItem.prefab, slotIndex);
		//equippedItems [itemIndex] = newMesh.gameObject;

	}

	void AttachToMesh(SkinnedMeshRenderer mesh, int slotIndex) {

		if (currentMeshes [slotIndex] != null) {
			Destroy (currentMeshes [slotIndex].gameObject);
		}

		SkinnedMeshRenderer newMesh = Instantiate(mesh) as SkinnedMeshRenderer;
		newMesh.bones = targetMesh.bones;
		newMesh.rootBone = targetMesh.rootBone;
		currentMeshes [slotIndex] = newMesh;
	}

}
