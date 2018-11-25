using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision : MonoBehaviour {

	protected Pawn owner;
	protected DecisionManager decisionManager;

	public abstract void Decide ();

	void Awake() {
		owner = GetComponent<Pawn> ();
		decisionManager = GetComponent<DecisionManager> ();

		decisionManager.AddDecision (this);
	}
}
