using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour {

	public Interactable focus;

	NavMeshAgent agent;		// Reference to our NavMeshAgent
	Camera cam;				// Reference to our camera

	// Get references
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update () {

		// If we press left mouse
		if (Input.GetMouseButtonDown(0))
		{
			// Shoot out a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If we hit
			if (Physics.Raycast(ray, out hit))
			{
				SetFocus(hit.collider.GetComponent<Interactable>());
				Move(hit.point);
			}
		}

	}

	void SetFocus (Interactable newFocus)
	{
		// If our focus has changed
		if (focus != newFocus && focus != null)
		{
			// Let our previous focus know that it's no longer being focused
			focus.OnDefocused();
		}

		// Set our focus to what we hit
		// If it's not an interactable, simply set it to null
		focus = newFocus;
		
		if (focus != null)
		{
			// Let our focus know that it's being focused
			focus.OnFocused(agent);
		}

	}

	void Move (Vector3 point)
	{
		// If we have a focus we want to leave a bit of space
		if (focus == null)
			agent.stoppingDistance = 0f;
		else
			agent.stoppingDistance = 2f;

		// Move to the point
		agent.SetDestination(point);
	}

}
