using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour {

	NavMeshAgent agent;
    public DayNightController dnCtrl;
	public Vector3 destination;

	public Land currentLand;
	public Tile currentTile;

	// DEBUG
	public Camera cam;

    void Start() {
		cam = Camera.main;
		agent = GetComponent<NavMeshAgent> ();
        destination = transform.position;
	}
		
	/*
	 * DEBUG : Set the destination by clicking 
	 */
	void Update () {
        if (dnCtrl && dnCtrl.IsNight())
            return;
        
        if (Input.GetMouseButtonDown (1)) {
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				SetDestination (hit.point);
			}
		}

        MoveToDestination();
    }

	public bool IsArrivedAtDestination() {
		if (agent.remainingDistance != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0) {
			return true;
		}
		return false;
	}

	public void SetDestination(Vector3 newDestination) {
		destination = newDestination;
	}

	public void MoveToDestination() {
		agent.SetDestination (destination);
	}

	public void MoveToNextLand() {
		if (currentLand.nextLand != null) {
			SetDestination (currentLand.nextLand.transform.position);
		}
	}
}
