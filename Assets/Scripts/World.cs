using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	// Template of land used to create the world
	public GameObject[] landTemplates;

	// Total length of the world
	float worldLength = 0;

	void Start () {
		
		//Lands creation
		foreach (GameObject landTemplate in landTemplates) {
			GameObject newLand = Instantiate (landTemplate, transform);
			newLand.transform.position = new Vector3(worldLength, 0, 0);
			newLand.GetComponent<Land> ().CreateLand (worldLength, 0);
			worldLength += newLand.GetComponent<Land> ().landLength;
		}
	}
}
