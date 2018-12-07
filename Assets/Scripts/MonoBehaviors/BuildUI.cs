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
    public Button buildingButton;
    public float margin = 10;

    /*
	 *  Tile creation table
	*/
    [System.Serializable]
    public class BuildTemplate
    {
        // Build to be created
        public GameObject buildingPrefab;
        // The higher this number, the higher the chance of this tile to be created
        public Building building;
    }
    public List<BuildTemplate> buildingTemplates;

    // Use this for initialization
    void Start () {
        parentPanel.gameObject.SetActive(false);

        float height = buildingButton.GetComponent<RectTransform>().rect.height;

        foreach (var buildingName in this.buildingTemplates)
        {
            print($"construction de {buildingName.building._name}");

            //Button buildingListButton = Instantiate(buildingButton);

            //Text buildingTxt = buildingListButton.GetComponent<Text>();
            //buildingTxt.text = buildingName;

            //buildingListButton.transform.SetParent(parentPanel, false);
            //buildingListButton.transform.localScale = new Vector3(0, height + margin, 0);

            //buildingListButton.onClick.AddListener(() => OnBuildButtonClick(buildingName));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Display(bool visible, Build build = null)
    {
        if (build != null)
        {
            foreach(BuildTemplate buildTemp in buildingTemplates)
            {
                if (build.availableBuildingNames.Contains(buildTemp.building._name))
                {
                    print($"batiment {buildTemp.building._name} Disponible");
                }
            }
        }

        if (!visible)
            parentPanel.gameObject.SetActive(false);
        else 
            parentPanel.gameObject.SetActive(true);
    }
}
