using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Keeps track of enemy stats, loosing health and dying. */

public class EnemyStats : CharacterStats {

	public override void Die()
	{
		base.Die();

		// Add ragdoll effect / death animation

		Destroy(gameObject);
	}

}
