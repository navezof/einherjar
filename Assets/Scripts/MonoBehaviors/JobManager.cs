using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour {

	public Job currentJob;
	public Job[] jobs;


	void Start () {
		InitializeJobs ();
	}

	void InitializeJobs() {
		jobs = GetComponents<Job> ();

		print ("count job : " + jobs.Length);

		foreach (Job job in jobs) {
			job.enabled = false;
		}

		currentJob = jobs [0];
		jobs [0].enabled = true;
	}
}
