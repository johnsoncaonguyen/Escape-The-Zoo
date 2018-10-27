﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICop : MonoBehaviour {
    public GameObject player;
    NavMeshAgent nav_mesh;
    Animation anim;
    VelocityReporter vReporter;
    public GameObject[] waypoints;
    int currWaypoint = -1;
    public enum AIStates { Patrol, Chase }
    AIStates AIstate;
    public float chaseDistance;
    // Use this for initialization
    void Start()
    {
        nav_mesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();
        vReporter = player.GetComponent<VelocityReporter>();

        AIstate = AIStates.Patrol;
        SetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = (player.transform.position - this.transform.position);
        float dir = Vector3.Dot(this.transform.forward,distanceToPlayer);
        switch (AIstate)
        {
            case AIStates.Patrol:
                if (!nav_mesh.pathPending && nav_mesh.remainingDistance < 0.5f)
                {
                    if (currWaypoint + 1 == waypoints.Length)
                    {
                        AIstate = AIStates.Chase;
                        ChaseWaypoint();
                    }
                    else
                        SetNextWaypoint();
                }
                if (distanceToPlayer.magnitude < chaseDistance && dir > 0)
                    AIstate = AIStates.Chase;
                if (!anim.isPlaying)
                    anim.Play("Take 001");

                break;
            case AIStates.Chase:
                if (distanceToPlayer.magnitude > chaseDistance || dir < 0)
                    AIstate = AIStates.Patrol;
                if (!nav_mesh.pathPending && nav_mesh.remainingDistance < 1.5f)
                {
                    AIstate = AIStates.Patrol;
                    SetNextWaypoint();
                }
                else
                {
                    ChaseWaypoint();
                
                }
                if(!anim.isPlaying)
                    anim.Play("Take 001");

                break;
        }

    }
    private void ChaseWaypoint()
    {
        Vector3 targetVel = vReporter.Velocity;
        Vector3 predictedPosition = vReporter.prevPos + vReporter.Velocity * Time.deltaTime;
        nav_mesh.SetDestination(predictedPosition);
    }
    private void SetNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            print("Error: Length of waypoints zero");
            return;
        }
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
        nav_mesh.SetDestination(waypoints[currWaypoint].transform.position);

    }
}
