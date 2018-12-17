using Assets.Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Display Build menu and create all buildings on the Tile
/// </summary>
public class BuildUI : MonoBehaviour {

    // UI 
    public Transform parentPanel;
    public Text title;
    public Button buildingBtn;
    public float margin = 10;

    /*
	 *  Building creation table
	*/
    [System.Serializable]
    public class BuildingTemplate
    {
        // Build to be created
        public GameObject buildingPrefab;
        public Building building;
    }
    public List<BuildingTemplate> buildingTemplates;

    public Build CurrentTile;

    // Use this for initialization
    void Start () {
        parentPanel.gameObject.SetActive(false);
        CurrentTile = null;

        float height = buildingBtn.GetComponent<RectTransform>().rect.height;

        foreach (var buildingTemplate in this.buildingTemplates)
        {
            print($"construction de {buildingTemplate.building._name}");

            Button buildingListButton = Instantiate(buildingBtn);
            Text buildingTxt = buildingListButton.GetComponentInChildren<Text>();
            buildingTxt.text = buildingTemplate.building._name;

            buildingListButton.transform.SetParent(parentPanel, false);
            buildingListButton.onClick.AddListener(() => OnBuildButtonClick(buildingTemplate));
        }
    }
	
	// Update is called once per frame
	void Update () {
        //If player presses escape and game is not paused. Pause game. If game is paused and player presses escape, unpause.
        if (Input.GetKeyDown(KeyCode.Escape))
            parentPanel.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Display(false);
    }

    public void Display(bool visible, Build build = null)
    {
        if (!visible)
        {
            parentPanel.gameObject.SetActive(false);
            return;
        }
       
        parentPanel.gameObject.SetActive(true);

        if (build != null)
        {
            foreach(BuildingTemplate buildTemp in buildingTemplates)
            {
                if (build.availableBuildingNames.Contains(buildTemp.building._name))
                {
                    CurrentTile = build;
                    print($"batiment {buildTemp.building._name} Disponible");
                }
            }
        }

       
    }

    #region Events
    void OnBuildButtonClick(BuildingTemplate buildingTemplate)
    {
        print("lancement de la construction " + buildingTemplate.building._name);
        Vector3 tilePosition = this.CurrentTile.gameObject.transform.position;
        tilePosition.y += 50;
        GameObject newBuilding = Instantiate(buildingTemplate.buildingPrefab, tilePosition, Quaternion.identity);

        this.Display(false);
        this.CurrentTile.SetBuilding(true);
    }
    #endregion
}
