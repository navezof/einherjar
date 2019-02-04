using Assets.Constants;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NightAfraid : MonoBehaviour
{
    NavMeshAgent agent;
    public Vector3 destination;
    public DayNightController dnCtrl;

    // DEBUG
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dnCtrl && !dnCtrl.IsNight())
            return;
        
        MoveToClosestFirePit();
    }

    public bool IsArrivedAtDestination()
    {
        if (agent.remainingDistance != Mathf.Infinity 
            && agent.pathStatus == NavMeshPathStatus.PathComplete 
            && agent.remainingDistance == 0)
            return true;
        return false;
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
    }

    public void MoveToDestination()
    {
        agent.SetDestination(destination);
    }

    public void MoveToClosestFirePit()
    {
        List<Transform> firePitTransforms = GameObject.FindGameObjectsWithTag(BuildingType.FIRE_PIT)
            .Select((b) => (b.transform))
            .ToList();

        SetDestination(this.getClosestFirePitPosition(firePitTransforms));
        MoveToDestination();
    }

    private Vector3 getClosestFirePitPosition(List<Transform> transforms)
    {
        if (transforms.Count == 0)
            return this.transform.position;

        Transform closest = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in transforms)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closest = potentialTarget;
            }
        }

        return closest.position;
    }
}
