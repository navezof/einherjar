using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour {

	public Pawn owner;

	List<Job> jobs = new List<Job>();

	public JobsUI ui;
	public GameObject[] startingJobs;

	void Start () {
		owner = GetComponent<Pawn> ();

		InitializeJobs ();
	}

	void InitializeJobs() {
		foreach (GameObject job in startingJobs) {
			GameObject newJob = Instantiate (job, this.transform);
			newJob.GetComponent<Job> ().owner = owner;
		}
	}

	void OnMouseDown() {
		print ("click on jobs of " + gameObject.name);

		ui.Setup (owner);
		ui.Display (true);
	}
}
