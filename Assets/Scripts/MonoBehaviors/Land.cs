using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour {

	/* Value used at the creation of the land*/
	public float lengthMin;
	public float lengthMax;

	public float widthMin;
	public float widthMax;
	/**/

	// Length after creation of the land
	public float landLength;

	/*
	 *  Tile creation table
	*/
	[System.Serializable]
	public class TileTemplate
	{
		// Tile to be created
		public GameObject tile;
		// The higher this number, the higher the chance of this tile to be created
		public float rarity;
	}

	/*Template of the tile to use*/
	public List<TileTemplate> tileTemplates;

	// List of tiles contained within this land
	List<GameObject> tiles = new List<GameObject>();

	/*
	 * Generate a randomly created land
	 */
	public void CreateLand(float newOriginX, float newOriginZ) {
		landLength = (int) Random.Range(lengthMin, lengthMax);
		int x = 0;
		while (x < landLength) {
			int landWidth = (int) Random.Range (widthMin, widthMax);
			int z = (int) Random.Range(widthMin, widthMax) * (-1);
			while (z < landWidth) {
				GameObject newTile = Instantiate (GetTile(), transform);
				newTile.transform.localPosition = new Vector3 (x, 0, z);
				newTile.gameObject.name = name + x + z;

				tiles.Add (newTile);
				z++;
			}
			x++;
		}

		transform.position = new Vector3(newOriginX, newOriginZ);
	}

	/*
	 * Get a random tile depending on its rarity 
	 */
	GameObject GetTile() {
		float itemWeight = 0;

		foreach (TileTemplate tileTemplate in tileTemplates) {
			itemWeight += tileTemplate.rarity;
		}

		float roll = Random.Range (0, itemWeight);

		foreach (TileTemplate tileTemplate in tileTemplates) {
			if (roll <= tileTemplate.rarity) {
				return tileTemplate.tile;
			}
			roll -= tileTemplate.rarity;
		}
		return null;
	}

	public GameObject GetRandomTile() {
		int roll = Random.Range (0, tiles.Count);
		return tiles [roll];
	}
}
