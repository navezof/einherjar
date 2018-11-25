﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BodyUI : GameUI {

	public Text age;

	Body body;

	void Update () {
		base.Update ();

		if (displayed) {
			title.text = body.gameObject.name + " : Body";
			age.text = body.age.ToString();
		}
	}

	public override void SetSubject(Pawn pawn) {

		if (!pawn)
			print ("pawn is null");

		owner = pawn;
		body = pawn.GetComponent<Body> ();
	}
}
