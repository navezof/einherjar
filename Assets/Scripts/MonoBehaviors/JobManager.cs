using Assets.Constants;
using System.Linq;
using UnityEngine;

public class JobManager : MonoBehaviour {

	public Job currentJob;
	public Job[] jobs;
    JobUI jobUI;

    void Awake()
    {
        GameObject globalUis = GameObject.Find(Global.UI_CONTAINER);
        if (globalUis == null)
            throw new System.Exception($"Can't find global UIs Game Object named : ${Global.UI_CONTAINER}");
        this.jobUI = globalUis.GetComponentsInChildren<JobUI>().First();
    }

    void Start () {
		InitializeJobs ();
	}

	void InitializeJobs() {
		jobs = GetComponentsInChildren<Job> ();

		print ("count job : " + jobs.Length);

		foreach (Job job in jobs) {
			job.enabled = false;
		}
	}

    void OnMouseDown()
    {
        jobUI.Display(true, this);
    }

    public void SetJob(Job selectedJob)
    {
        foreach (Job job in jobs)
        {
            job.enabled = false;
        }

        this.currentJob = selectedJob;
        selectedJob.enabled = true;
    }
}
