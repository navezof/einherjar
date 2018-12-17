using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public Land land;

	void OnTriggerEnter(Collider collider) {
		Move mover = collider.gameObject.GetComponent<Move> ();
		if (mover) {
			mover.currentTile = this;

			if (mover.currentLand != land) {
				print ("<" + mover.name + "> : I'm entering a new land : " + land.name);
				mover.currentLand = land;
				mover.SendMessage ("EnterLand", land);
			}
		}
	}
}
