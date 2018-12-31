using UnityEngine;
using UnityEngine.UI;

public class JobUI : MonoBehaviour {

    public Button jobBtn;
    public float margin = 10;

    JobManager _jobsManager;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) 
                && gameObject.activeSelf)
            gameObject.SetActive(false);
    }

    public void Display(bool visible, JobManager jobsManager = null)
    {
        this._jobsManager = jobsManager;
        this.gameObject.SetActive(visible);
        if (jobsManager != null)
        {
            GenerateButton(jobsManager.jobs);
            // Display near the pawn
            transform.localPosition = jobsManager.transform.localPosition;
        }
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

            jobListButton.transform.SetParent(gameObject.transform, false);
            Vector3 position = new Vector3(jobListButton.transform.position.x, jobListButton.transform.position.y + yPosition);
            jobListButton.transform.position​ = position;
            yPosition -= (btnHeight + margin);
            jobListButton.onClick.AddListener(() => OnJobButtonClick(availableJob));
        }
    }

    public void OnJobButtonClick(Job selectedJob)
    {
        _jobsManager.SetJob(selectedJob);
        Display(false);
    }

}
