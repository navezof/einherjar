using Assets.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a Unit of land. Allow interactions with users 
/// </summary>
public class Tile : MonoBehaviour
{
    public TileUI ui;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplayUI(bool display)
    {
        ui.Display();
    }

    public void DisplayUI()
    {
        ui.Display();
    }

    // TODO - déplacer dans le TileUI
    void OnMouseDown()
    {
        ui.Setup(gameObject);
        ui.Display(true);
    }

    public void build()
    {
        print("construction du firepit");
    }
}
