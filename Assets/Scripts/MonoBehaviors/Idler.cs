using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idler : Job {

	Move mover;

	// Time in second waited before resuming random movement
	public float waitingTime;

	void Start() {
		mover = GetComponentInParent<Move> ();
	}
		
	void Update () {
		if (mover.IsArrivedAtDestination ()) {
			Invoke ("StopWaiting", waitingTime);
		}
	}

	void StopWaiting() {
		mover.SetDestination(mover.currentLand.GetRandomTile ().transform.position);
	}
}
