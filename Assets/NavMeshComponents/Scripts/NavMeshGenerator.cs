﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour {

	public NavMeshSurface surface;
	// Use this for initialization

	void Start () {
		surface.BuildNavMesh ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
