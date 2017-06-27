using UnityEngine;

/* Makes the camera follow the player */

public class CameraController : MonoBehaviour {

	public Transform target;

	public Vector3 offset;
	public float smoothSpeed = 2f;

	public float currentZoom = 1f;
	public float maxZoom = 3f;
	public float minZoom = .3f;
	public float yawSpeed = 70;
	public float zoomSensitivity = .7f;
	float dst;

	float zoomSmoothV;
	float targetZoom;

	void Start() {
		dst = offset.magnitude;
		transform.LookAt (target);
		targetZoom = currentZoom;
	}

	void Update ()
	{
		float scroll = Input.GetAxisRaw("Mouse ScrollWheel") * zoomSensitivity;

		if (scroll != 0f)
		{
			targetZoom = Mathf.Clamp(targetZoom - scroll, minZoom, maxZoom);
		}
		currentZoom = Mathf.SmoothDamp (currentZoom, targetZoom, ref zoomSmoothV, .15f);
	}

	void LateUpdate () {
		transform.position = target.position - transform.forward * dst * currentZoom;
		transform.LookAt(target.position);

		float yawInput = Input.GetAxisRaw ("Horizontal");
		transform.RotateAround (target.position, Vector3.up, -yawInput * yawSpeed * Time.deltaTime);
	}

}
