using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Job : MonoBehaviour {

	public Pawn owner;

	public int priority;

	public abstract void DoJob ();
}
