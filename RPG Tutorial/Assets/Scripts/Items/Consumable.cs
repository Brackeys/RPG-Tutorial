using UnityEngine;

/* An Item that can be consumed. So far that just means regaining health */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Consumable")]
public class Consumable : Item {

	public int healthGain;		// How much health?

	// This is called when pressed in the inventory
	public override void Use()
	{
		// Heal the player
		PlayerStats playerStats = Player.instance.playerStats;
		playerStats.Heal(healthGain);

		Debug.Log(name + " consumed!");

		RemoveFromInventory();	// Remove the item after use
	}

}
