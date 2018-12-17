using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {

	List<Land> knownLand = new List<Land>();

	public void EnterLand(Land enteredLand) {
		print("<Memory>enter new land : " + enteredLand.name);
		knownLand.Add (enteredLand);
	}
}
