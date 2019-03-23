using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;

    NavMeshAgent playerNavMeshAgent;

    void Start()
    {
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        playerNavMeshAgent.SetDestination(target.position);
    }
}
