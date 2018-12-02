using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour {

	public bool isSleeping = false;

	public SleepUI ui;

	public double energyMax;
	public double energyCurrent;
	public double energyMaxDebuff;

	public double energyThreshold;

	void Start() {
	}

	void Update () {
		if (isSleeping) {
			if (energyCurrent >= energyMax) {
				StopSleeping ();
			} else {
				ContinueSleeping ();
				return;
			}
		}

		ConsumEnergy ();

		if (energyCurrent <= energyThreshold) {
			StartSleeping ();
		}
	}

	bool IsNextToPlaceToRest() {
		return true;
	}

	void StartSleeping() {
		isSleeping = true;
	}

	void StopSleeping() {
		isSleeping = false;
	}

	void ContinueSleeping() {
		energyCurrent += 0.2;
		if (energyCurrent >= energyMax) {
			energyCurrent = energyMax;
		}
	}

	public void ConsumEnergy() {
		energyCurrent -= 0.1f;
	}

	void OnMouseDown() {
		ui.Setup (this.gameObject);
		ui.Display (true);
	}
}
