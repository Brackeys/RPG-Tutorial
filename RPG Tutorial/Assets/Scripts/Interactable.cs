using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

	bool isFocus = false;
	NavMeshAgent agent;

	bool hasInteracted = false;

	void Update ()
	{
		if (isFocus)
		{
			if (!hasInteracted && agent.remainingDistance <= agent.stoppingDistance)
			{
				hasInteracted = true;
				Interact();
			}
		}
	}

	public void OnFocused (NavMeshAgent _agent)
	{
		isFocus = true;
		agent = _agent;
    }

	public void OnDefocused ()
	{
		isFocus = false;
		hasInteracted = false;
		agent = null;
	}

	public virtual void Interact ()
	{
		Debug.Log("Interacting with " + gameObject.name);
	}

}
