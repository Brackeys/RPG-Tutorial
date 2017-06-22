using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public Stat maxHealth;
	private int currentHealth;

	public Stat armor;

	void Start ()
	{
		EquipmentManager.instance.onItemEquippedCallback += OnEquippedItem;

		currentHealth = maxHealth.GetValue();
	}

	public void TakeDamage (int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			Debug.Log("PLAYER DEATH");
		}
	}

	void OnEquippedItem (Equipment newItem, Equipment oldItem)
	{
		armor.AddModifier(newItem.armorModifier);

		if (oldItem != null)
			armor.RemoveModifier(oldItem.armorModifier);
	}

}
