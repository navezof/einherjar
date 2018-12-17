using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

	public GameObject owner;
	public BodyUI ui;

	public double age;
	// Use this for initialization

	void Start () {
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
		ui.Setup (this.gameObject);
		ui.Display (true);
	}
}
