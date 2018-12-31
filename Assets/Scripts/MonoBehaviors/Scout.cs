using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : Job {

	Move move;

	public bool debug = false;

	void Start() {
        jobName = "Scout";
        move = GetComponentInParent<Move> ();
	}

	public void Update() {
		if (move.currentLand.explored >= 100f) {
			move.MoveToNextLand ();
		} else {
			move.currentLand.explored += 1f;
		}
	}

    private void OnEnable()
    {
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponentInParent<Renderer>();
        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.red);
    }

    private void OnDisable()
    {
        //Fetch the Renderer from the GameObject
        Renderer rend = GetComponentInParent<Renderer>();
        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.white);
    }
}
