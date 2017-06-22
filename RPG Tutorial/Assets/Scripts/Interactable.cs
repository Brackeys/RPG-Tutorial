using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ColorOnHover))]
public class Interactable : MonoBehaviour {

	bool isFocus = false;	// Is this interactable currently being focused?
	NavMeshAgent agent;		// Reference to the NavMeshAgent on the player

	bool hasInteracted = false;	// Have we already interacted with the object?

	void Update ()
	{
		if (isFocus)	// If currently being focused
		{
			float distance = Vector3.Distance(agent.transform.position, transform.position);
			// If we haven't already interacted and the player is close enough
			if (!hasInteracted && distance <= agent.stoppingDistance)
			{
				// Interact with the object
				hasInteracted = true;
				Interact();
			}
		}
	}

	// Called when the object starts being focused
	public void OnFocused (NavMeshAgent _agent)
	{
		isFocus = true;
		agent = _agent;
    }

	// Called when the object is no longer focused
	public void OnDefocused ()
	{
		isFocus = false;
		hasInteracted = false;
		agent = null;
	}

	// This method is meant to be overwritten
	public virtual void Interact ()
	{
		Debug.Log("Interacting with " + gameObject.name);
	}

}
