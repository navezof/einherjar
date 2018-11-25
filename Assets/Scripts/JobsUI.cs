using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class JobsUI : GameUI {

	JobManager jobs;

	void Update() {
		base.Update ();

		if (displayed) {
			title.text = jobs.gameObject.name + " : Jobs";
		}
	}

	public override void SetSubject(Pawn pawn) {
		owner = pawn;
		jobs = pawn.GetComponent<JobManager> ();
	}
}
