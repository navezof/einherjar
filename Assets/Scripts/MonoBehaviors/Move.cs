using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Move : MonoBehaviour {

	NavMeshAgent agent;

	public Vector3 destination;

	// DEBUG
	public Camera cam;

	void Start() {
		cam = Camera.main;
		agent = GetComponent<NavMeshAgent> ();
	}
		
	/*
	 * DEBUG : Set the destination b clicking 
	 */
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				SetDestination (hit.point);
			}
		}

		MoveToDestination ();
	}

	public void SetDestination(Vector3 newDestination) {
		destination = newDestination;
	}

	void MoveToDestination() {
		agent.SetDestination (destination);
	}
}
