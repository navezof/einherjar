using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

	public Pawn owner;

	public BodyUI ui;

	public double age;

	// Use this for initialization

	void Start () {
		owner = GetComponent<Pawn> ();
	}
	
	// Update is called once per frame
	void Update () {
		age += 1;
	}

	public void DisplayUI(bool display) {
		ui.Display ();
	}

	public void DisplayUI() {
		ui.Display ();
	}

	void OnMouseDown() {
		ui.Setup (owner);
		ui.Display (true);
	}
}
