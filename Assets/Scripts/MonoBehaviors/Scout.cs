using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Job {

	Move move;

	public bool debug = false;

	void Start() {
		move = GetComponentInParent<Move> ();
	}

	public void Update() {
		if (move.currentLand.explored >= 100f) {
			move.MoveToNextLand ();
		} else {
			move.currentLand.explored += 1f;
		}
	}
}
