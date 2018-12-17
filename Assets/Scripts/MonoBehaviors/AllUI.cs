using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUI : MonoBehaviour {

	public static AllUI ui;

	List<GameUI> gameUIs = new List<GameUI>();

	void Awake() {
		ui = this;
	}

	void Start () {
		GameUI[] allGameUI = GetComponentsInChildren<GameUI> ();
		foreach (GameUI gameUI in allGameUI) {
			print ("adding : " + gameUI.gameObject.name);
			gameUI.gameObject.SetActive (false);
			gameUIs.Add (gameUI);
		}
	}
	
	public void ResetUI() {
		foreach (GameUI gameUI in gameUIs) {
			gameUI.Display(false);
		}
	}
}
