﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public abstract class GameUI : MonoBehaviour {

	public GameObject parent;
	public GameObject panel;
	public Text title;

	public bool displayed = false;

	public Pawn owner;

	public abstract void SetSubject (Pawn subject);

	public void Display(bool display) {
		displayed = display;

		gameObject.SetActive (displayed);
		if (parent) {
			parent.GetComponent<GameUI> ().Display (displayed);
		}
	}

	public void Display() {
		displayed = !displayed;

		Display (displayed);
	}

	protected void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			AllUI.ui.ResetUI ();
		}
	}

	public void Setup(Pawn owner) {
		SetSubject (owner);
		if (parent)
			parent.GetComponent<GameUI> ().Setup (owner);
		AllUI.ui.ResetUI ();
	}
}
