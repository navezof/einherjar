using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SleepUI : GameUI {

	public Text energyText;

	Sleep subjectSleep;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

		if (displayed) {
			title.text = subjectSleep.gameObject.name + " : Energy";
			energyText.text = subjectSleep.energyCurrent + "/" + subjectSleep.energyMax;
		} else {
			Display (false);
		}
	}

	public override void SetSubject(GameObject pawn) {
		subjectSleep = pawn.GetComponent<Sleep> ();
	}
}
