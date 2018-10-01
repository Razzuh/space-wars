using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyMover : MonoBehaviour {

    
    public Transform[] NavWaypoints;
    public Transform ThePlayer;

    private NavMeshAgent agent;
    private int currentWayPointIndex;
    private bool chasingPlayer;


	// Use this for initialization
	void Start () {
        agent = transform.GetComponent<NavMeshAgent>();
        currentWayPointIndex = 0;
        chasingPlayer = false;
	}

    // Update is called once per frame
    void Update() {
        float distToPlayer = (ThePlayer.position - transform.position).magnitude;

        if (distToPlayer < 25.0f)
        {
            chasingPlayer = true;
        }
        else
        {   //if we are chasing the player, turn back to the current 
            if (chasingPlayer == true)
            {
                GoToCurrentWayPoint();
            }
            chasingPlayer = false;
        }

        if (chasingPlayer == true)
        {
            agent.SetDestination(ThePlayer.position);
        }
        else
        {





            //checks if agent is close enough
            if (agent.remainingDistance < 3.0f)
            {
                ActivateNextWaypoint();
            }

        }
    }
    // go to current waypoint
    private void GoToCurrentWayPoint() {
        agent.SetDestination(NavWaypoints[currentWayPointIndex].position);
    }
    //activate the next waypoint
    private void ActivateNextWaypoint()
    {
        currentWayPointIndex = (currentWayPointIndex + 1) % NavWaypoints.Length;
        GoToCurrentWayPoint();
        /*
            0 0 1 1%4 = 1
            1 2 2 2%4 = 2
            2 3 3 3%4 = 3
            3 3 3 4%4 = 0
            */
        /*
        currentWayPointIndex++;
        if (currentWayPointIndex <= NavWaypoints.Length)
        {
            GoToCurrentWayPoint();
        }
        else
        {
            currentWayPointIndex
        }
        */
    }

}
