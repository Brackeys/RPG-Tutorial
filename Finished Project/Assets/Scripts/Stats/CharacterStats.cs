using UnityEngine;

/* Contains all the stats for a character. */

public class CharacterStats : MonoBehaviour {

	public Stat maxHealth;			// Maximum amount of health
	public int currentHealth {get;protected set;}	// Current amount of health

	public Stat damage;
	public Stat armor;

	public event System.Action OnHealthReachedZero;

	public virtual void Awake() {
		currentHealth = maxHealth.GetValue();
	}

	// Start with max HP.
	public virtual void Start ()
	{
		
	}

	// Damage the character
	public void TakeDamage (int damage)
	{
		// Subtract the armor value - Make sure damage doesn't go below 0.
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		// Subtract damage from health
		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + " damage.");

		// If we hit 0. Die.
		if (currentHealth <= 0)
		{
			if (OnHealthReachedZero != null) {
				OnHealthReachedZero ();
			}
		}
	}

	// Heal the character.
	public void Heal (int amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
	}



}
