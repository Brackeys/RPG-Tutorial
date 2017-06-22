using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : InventoryItem {

	public EquipmentSlot equipSlot;
	public int armorModifier;

	public override void Use ()
	{
		EquipmentManager.instance.Equip(this);
	}

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield }
