using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class World : MonoBehaviour {

	// Template of land used to create the world
	public GameObject[] landTemplates;

	// DEBUG: Villager to spawn
	public GameObject villager;

	// Total length of the world
	float worldLength = 0;

	// Navigation mesh surface of the world
	NavMeshSurface surface;

	//List of lands contained in the world
	List<Land> lands = new List<Land>();

	void Awake() {
		GenerateWorld ();
		UpdateNavMesh ();
		SpawnVillager ();
	}

	void GenerateWorld() {
		//Lands creation
		foreach (GameObject landTemplate in landTemplates) {
			GameObject newLand = Instantiate (landTemplate, transform);
			newLand.transform.position = new Vector3(worldLength, 0, 0);
			newLand.GetComponent<Land> ().CreateLand (worldLength, 0);
			lands.Add (newLand.GetComponent<Land>());

			worldLength += newLand.GetComponent<Land> ().landLength;
		}
	}

	/*
	 * Create the navmesh necessary for the navagent to move on
	 */
	void UpdateNavMesh() {
		surface = GetComponent<NavMeshSurface> ();

		surface.BuildNavMesh ();
	}

	/*
	 * DEBUG: Create a villager on the first land
	 */
	void SpawnVillager() {
		GameObject newVillager = Instantiate (villager, lands [0].transform.position + new Vector3 (0, 0.5f, 0), lands [0].transform.rotation);
	}
}
