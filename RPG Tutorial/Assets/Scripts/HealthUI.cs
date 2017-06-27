using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {

	const float stayTime = 3;

	public Transform target;
	public CharacterStats stats;
	public RectTransform healthSlider;
	public GameObject graphic;
	Transform cam;

	float healthPercentOld;
	float lastHealthChangeTime;


	void Start () {
		cam = Camera.main.transform;
		graphic.SetActive (false);
		healthPercentOld = GetHealthPercent ();
	}

	void LateUpdate () {
		transform.position = target.position;
		transform.LookAt (cam.position,Vector3.down);

		float healthPercent = GetHealthPercent ();
		healthSlider.localScale = new Vector3 (healthPercent, 1, 1);

		if (!Mathf.Approximately(healthPercent,healthPercentOld)) {
			healthPercentOld = healthPercent;
			lastHealthChangeTime = Time.time;
			graphic.SetActive (true);
		}

		if (Time.time - lastHealthChangeTime > stayTime) {
			graphic.SetActive (false);
		}
	}

	float GetHealthPercent() {
		return Mathf.Clamp01(stats.currentHealth / (float)stats.maxHealth.GetValue ());
	}
}
