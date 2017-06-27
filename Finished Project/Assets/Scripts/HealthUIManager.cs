using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIManager : MonoBehaviour {

	public HealthUI healthUIPrefab;
	public static HealthUIManager instance;

	void Awake() {
		instance = this;
	}

	public void Create(Transform target, CharacterStats stats) {
		HealthUI newUI = Instantiate (healthUIPrefab, transform) as HealthUI;
		newUI.Init (target, stats);
	}
}
