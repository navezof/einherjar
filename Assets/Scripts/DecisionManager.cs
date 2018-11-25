using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionManager : MonoBehaviour {

	List<Decision> decisions = new List<Decision>();

	void Update () {
		foreach (Decision decision in decisions) {
			decision.Decide ();
		}
	}

	public void AddDecision(Decision decision) {
		decisions.Add (decision);
	}
}
