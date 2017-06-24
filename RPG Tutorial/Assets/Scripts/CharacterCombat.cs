using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This resorts combat for all characters. */

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	public float attackRate = 1f;
	private float attackCountdown = 0f;

	CharacterStats myStats;

	void Start ()
	{
		myStats = GetComponent<CharacterStats>();
	}

	void Update ()
	{
		attackCountdown -= Time.deltaTime;
	}

	public void Attack (CharacterStats enemyStats)
	{
		if (attackCountdown <= 0f)
		{
			Debug.Log(transform.name + " swings for " + myStats.damage.GetValue() + " damage");
			enemyStats.TakeDamage(myStats.damage.GetValue());
			attackCountdown = 1f / attackRate;
		}
	}

}
