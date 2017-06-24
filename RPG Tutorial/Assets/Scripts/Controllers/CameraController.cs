using UnityEngine;

/* Makes the camera follow the player */

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector3 offset;

	public float currentZoom = 1f;
	public float maxZoom = 3f;
	public float minZoom = .3f;

	void Update ()
	{
		float scroll = Input.GetAxis("Mouse ScrollWheel");

		if (scroll != 0f)
		{
			currentZoom -= scroll;
			currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
		}
	}

	void LateUpdate () {
		transform.position = target.position + offset * currentZoom;
		transform.LookAt(target.position);
	}
}
