using Assets.Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Display Build menu and create all buildings on the Tile
/// </summary>
public class BuildUI : MonoBehaviour {

    // UI 
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
        gameObject.SetActive(false);
        CurrentTile = null;
        float height = buildingBtn.GetComponent<RectTransform>().rect.height;

        foreach (var buildingTemplate in this.buildingTemplates)
        {
            print($"construction de {buildingTemplate.building._name}");

            Button buildingListButton = Instantiate(buildingBtn);
            Text buildingTxt = buildingListButton.GetComponentInChildren<Text>();
            buildingTxt.text = buildingTemplate.building._name;

            buildingListButton.transform.SetParent(gameObject.transform, false);
            buildingListButton.onClick.AddListener(() => OnBuildButtonClick(buildingTemplate));
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameObject.SetActive(false);
    }

    public void Exit()
    {
        Display(false);
    }

    public void Display(bool visible, Build build = null)
    {
        if (!visible)
        {
            gameObject.SetActive(false);
            return;
        }
       
        gameObject.SetActive(true);

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
        CurrentTile.SetBuilding(buildingTemplate);
        this.Display(false);
    }
    #endregion
}
