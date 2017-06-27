using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {

	const float stayTime = 3;


	public RectTransform healthSlider;
	public GameObject graphic;

	Transform cam;
	Transform target;
	CharacterStats stats;

	float healthPercentOld;
	float lastHealthChangeTime;

	public void Init(Transform target, CharacterStats stats) {
		this.target = target;
		this.stats = stats;

		cam = Camera.main.transform;
		graphic.SetActive (false);
		healthPercentOld = GetHealthPercent ();
	}

	void LateUpdate () {
		if (target == null) {
			Destroy (gameObject);
			return;
		}
		transform.position = target.position;
		transform.LookAt (new Vector3(cam.position.x,transform.position.y,cam.position.z), Vector3.down);

		float healthPercent = GetHealthPercent ();
		healthSlider.localScale = new Vector3 (healthPercent, 1, 1);

		if (!Mathf.Approximately (healthPercent, healthPercentOld)) {
			healthPercentOld = healthPercent;
			lastHealthChangeTime = Time.time;
			graphic.SetActive (true);
		}

		if (graphic.activeSelf) {
			if (Time.time - lastHealthChangeTime > stayTime) {
				graphic.SetActive (false);
			}
		}
		
	
	}

	float GetHealthPercent() {
		return Mathf.Clamp01(stats.currentHealth / (float)stats.maxHealth.GetValue ());
	}
}
