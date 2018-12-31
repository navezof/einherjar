using Assets.Constants;
using Assets.Scripts.Entities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static BuildUI;

/// <summary>
/// Build - Allow interactions with users for building
/// </summary>
public class Build : MonoBehaviour
{
    BuildUI buildUI;
    // Business Logic - passer en Building Template (GO)
    public List<string> availableBuildingNames = new List<string>()
    {
        BuildingType.FIRE_PIT
    };

    private bool isBuilded;

    void Awake()
    {
        GameObject globalUis = GameObject.Find(Global.UI_CONTAINER);
        if (globalUis == null)
            throw new System.Exception($"Can't find global UIs Game Object named : {Global.UI_CONTAINER}");
        this.buildUI = globalUis.GetComponentsInChildren<BuildUI>().First();
    }
    // Use this for initialization
    void Start()
    {
        isBuilded = false;
        buildUI.Display(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        if (isBuilded)
            print("bim, déjà un batiment");
        else
        {
            buildUI.Display(true, this);
        }
    }

    /// <summary>
    /// Called by UI when building is done on this Tile
    /// </summary>
    /// <param name="isBuilded"></param>
    public void SetBuilding(BuildingTemplate buildingTemplate)
    {
        print("lancement de la construction " + buildingTemplate.building._name);
        Vector3 tilePosition = gameObject.transform.position;
        tilePosition.y += 0.7f;
        GameObject newBuilding = Instantiate(buildingTemplate.buildingPrefab);
        newBuilding.transform.SetParent(gameObject.transform);
        newBuilding.transform.position = tilePosition;

        this.isBuilded = true;
    }
}
