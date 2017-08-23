using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Keeps track of the player */

public class PlayerManager : MonoBehaviour {

	#region Singleton

	public static PlayerManager instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

	public GameObject player;

}
