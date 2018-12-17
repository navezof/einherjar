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
    public Text youWinText;

    private World world;
    // Start is called before the first frame update
    void Start()
    {
        world = GetComponent<World>();
        if (world == null)
            print("No world script attached");
        else 
            youWinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool youWin = !world.lands.Any((Land land) => land.explored != 100f);
        if (youWin)
            youWinText.gameObject.SetActive(true);
    }
}
