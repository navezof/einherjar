using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SleepUI : GameUI {

	public Text energyText;

	Sleep subjetSleep;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

		if (displayed) {
			title.text = subjetSleep.gameObject.name + " : Energy";
			energyText.text = subjetSleep.energyCurrent + "/" + subjetSleep.energyMax;
		} else {
			Display (false);
		}
	}

	public override void SetSubject(Pawn pawn) {
		owner = pawn;
		subjetSleep = pawn.GetComponent<Sleep> ();
	}
}
