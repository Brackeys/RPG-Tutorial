using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This resorts combat for all characters. */

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	public float attackRate = 1f;
	private float attackCountdown = 0f;

	public event System.Action OnAttack;

	public Transform healthBarPos;

	CharacterStats myStats;

	void Start ()
	{
		myStats = GetComponent<CharacterStats>();
		HealthUIManager.instance.Create (healthBarPos, myStats);
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

			if (OnAttack != null) {
				OnAttack ();
			}
		}
	}


}
