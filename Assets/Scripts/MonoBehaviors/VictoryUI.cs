using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Determine whether all lands are explored or not 
/// </summary>
public class VictoryUI : MonoBehaviour
{
    private World world;
    public Transform panel;
    // Start is called before the first frame update
    void Start()
    {
        world = FindObjectsOfType<World>().First();
        if (world == null)
            print("No world script attached");
        else
            panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool youWin = !world.lands.Any((Land land) => land.explored != 100f);
        if (youWin)
            panel.gameObject.SetActive(true); 
    }
}
