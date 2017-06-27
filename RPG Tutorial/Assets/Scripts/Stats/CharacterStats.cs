using UnityEngine;

/* Contains all the stats for a character. */

public class CharacterStats : MonoBehaviour {

	public Stat maxHealth;			// Maximum amount of health
	public int currentHealth {get;protected set;}	// Current amount of health

	public Stat damage;
	public Stat armor;

	// Start with max HP.
	public virtual void Start ()
	{
		currentHealth = maxHealth.GetValue();
	}

	// Damage the character
	public void TakeDamage (int damage)
	{
		// Subtract the armor value - Make sure damage doesn't go below 0.
		damage -= armor.GetValue();
		Mathf.Clamp(damage, 0, 99999);

		// Subtract damage from health
		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + " damage.");

		// If we hit 0. Die.
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	// Heal the character.
	public void Heal (int amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
	}

	// Die. This can be overwritten.
	public virtual void Die ()
	{
		Debug.Log(transform.name + " died.");
		Destroy(gameObject);
	}

}
