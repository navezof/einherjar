using Assets.Constants;
using Assets.Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Build - Allow interactions with users for building
/// </summary>
public class Build : MonoBehaviour
{
    public BuildUI buildUI;
    // Business Logic - passer en Building Template (GO)
    public List<string> availableBuildingNames = new List<string>()
    {
        BuildingType.FIRE_PIT
    };

    private bool isBuilded;

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
    public void SetBuilding(bool isBuilded)
    {
        this.isBuilded = isBuilded;
    }
}
