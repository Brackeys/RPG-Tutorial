using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour {

	public Interactable focus;

	public LayerMask movementMask;
	public LayerMask interactionMask;

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

		if (EventSystem.current.IsPointerOverGameObject())
			return;

		// If we press left mouse
		if (Input.GetMouseButtonDown(0))
		{
			// Shoot out a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If we hit
			if (Physics.Raycast(ray, out hit, movementMask))
			{
				agent.SetDestination(hit.point);
				SetFocus(null);
			}
		}

		// If we press right mouse
		if (Input.GetMouseButtonDown(1))
		{
			// Shoot out a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If we hit
			if (Physics.Raycast(ray, out hit, 100f, interactionMask))
			{
				agent.SetDestination(hit.collider.transform.position);
				SetFocus(hit.collider.GetComponent<Interactable>());
			}
		}

	}

	// Set our focus to a new focus
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
			agent.stoppingDistance = 2f;
		} else
		{
			agent.stoppingDistance = 0f;
		}

	}

}
