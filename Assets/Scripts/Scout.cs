using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Job {



	public void Update() {
		print ("do scout");

		LookForClosestUnexploredLand ();
		MoveToClosestUnexploredLand ();
		Explore ();

		// Find unexeplored land
		// Go to unexplored land random point
		// Add completion to land
		// If land is explored
		// If no more land, do second job
	}

	void LookForClosestUnexploredLand () {
	}

	void MoveToClosestUnexploredLand () {
	}

	void Explore() {
		
	}
}
