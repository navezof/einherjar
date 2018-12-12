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
        BuildingType.FIRE_PIT,
        BuildingType.BLACK_SMITH
    };

    private bool isBuild;

    // Use this for initialization
    void Start()
    {
        buildUI.Display(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        buildUI.Display(true, this);
    }

    public void build()
    {
        print("construction du firepit");
    }
}
