using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This component moves our player using a NavMeshAgent. */

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

	Transform target;		// Target to follow
	NavMeshAgent agent;		// Reference to our agent

	// Get references
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}

	void Update ()
	{
		// If we have a target
		if (target != null)
		{
			// Move towards it and look at it
			agent.SetDestination(target.position);
			FaceTarget();
		}
	}
	
	public void MoveToPoint (Vector3 point)
	{
		agent.SetDestination(point);
	}

	// Start following a target
	public void FollowTarget (Interactable newTarget)
	{
		agent.stoppingDistance = newTarget.radius * .8f;
		agent.updateRotation = false;

		target = newTarget.interactionTransform;
	}

	// Stop following a target
	public void StopFollowingTarget ()
	{
		agent.stoppingDistance = 0f;
		agent.updateRotation = true;

		target = null;
	}

	// Make sure to look at the target
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

}
