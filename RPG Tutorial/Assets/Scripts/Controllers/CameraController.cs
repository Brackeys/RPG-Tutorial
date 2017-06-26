using UnityEngine;

/* Makes the camera follow the player */

public class CameraController : MonoBehaviour {

	public Transform target;

	public Vector3 offset;
	public float smoothSpeed = 2f;

	public float currentZoom = 1f;
	public float minZoom = .3f;
	public float maxZoom = 3f;
	public float zoomSensitivity = .7f;

	void Update ()
	{
		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
		currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
	}

	void LateUpdate () {
		Vector3 desiredPos = target.position - (target.forward + offset) * currentZoom;
		Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPos;

		transform.LookAt(target.position);
	}
}
