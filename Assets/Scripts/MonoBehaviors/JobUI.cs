using UnityEngine;
using UnityEngine.UI;

public class JobUI : MonoBehaviour {

    public Transform parentPanel;
    public Button jobBtn;
    public float margin = 10;

    JobManager _jobsManager;

    private void Start()
    {
        parentPanel.gameObject.SetActive(false);
    }

    void Update() {

    }

    public void OnJobButtonClick(Job selectedJob)
    {
        _jobsManager.SetJob(selectedJob);
        Display(false);
    }

    public void Display(bool visible, JobManager jobsManager = null)
    {
        this._jobsManager = jobsManager;
        this.parentPanel.gameObject.SetActive(visible);
        if (jobsManager != null)
            GenerateButton(jobsManager.jobs);
    }

    public void GenerateButton(Job[] jobs)
    {
        float btnHeight = jobBtn.GetComponent<RectTransform>().rect.height;
        float yPosition = 0;
        foreach (var availableJob in jobs)
        {
            Button jobListButton = Instantiate(this.jobBtn);
            Text buildingTxt = jobListButton.GetComponentInChildren<Text>();
            buildingTxt.text = availableJob.jobName;

            jobListButton.transform.SetParent(parentPanel, false);
            Vector3 position = new Vector3(jobListButton.transform.position.x, jobListButton.transform.position.y + yPosition);
            jobListButton.transform.position​ = position;
            yPosition -= (btnHeight + margin);
            jobListButton.onClick.AddListener(() => OnJobButtonClick(availableJob));
        }
    }
}
