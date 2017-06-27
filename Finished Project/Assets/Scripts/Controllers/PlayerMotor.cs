using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This component moves our player.
		- If we have a focus move towards that.
		- If we don't move to the desired point.
*/

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour {

	Transform target;
	NavMeshAgent agent;     // Reference to our NavMeshAgent

	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
		GetComponent<PlayerController>().onFocusChangedCallback += OnFocusChanged;
	}

	public void MoveToPoint (Vector3 point)
	{
		agent.SetDestination(point);
	}

	void OnFocusChanged (Interactable newFocus)
	{
		if (newFocus != null)
		{
			agent.stoppingDistance = newFocus.radius*.8f;
			agent.updateRotation = false;

			target = newFocus.interactionTransform;
		}
		else
		{
			agent.stoppingDistance = 0f;
			agent.updateRotation = true;
			target = null;
		}
	}

	void Update ()
	{
		if (target != null)
		{
			MoveToPoint (target.position);
			FaceTarget ();

		}
	}

	void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
		

}
