﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    NavMeshAgent playerNavMeshAgent;

    void Start()
    {
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        UpdateAnimator();
    }

    public void MoveTo(Vector3 destination)
    {
        playerNavMeshAgent.SetDestination(destination);
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}