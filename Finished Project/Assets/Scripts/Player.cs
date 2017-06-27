using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* This class just makes it faster to get certain components on the player. */

 public class Player : MonoBehaviour {

	#region Singleton

	public static Player instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

	void Start() {
		playerStats.OnHealthReachedZero += Die;
	}

	public CharacterCombat playerCombatManager;
	public PlayerStats playerStats;


	void Die() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
