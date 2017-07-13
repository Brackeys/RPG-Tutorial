using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* This component moves our player using a NavMeshAgent. */

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

	NavMeshAgent agent;		// Reference to our agent

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	public void MoveToPoint (Vector3 point)
	{
		agent.SetDestination(point);
	}
}
