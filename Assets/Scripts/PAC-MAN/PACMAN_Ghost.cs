using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PACMAN_Ghost : MonoBehaviour
{
    [SerializeField] private Transform[] targetList;

    [SerializeField] private Transform player;

    [SerializeField] private Transform defaultPosition;

    private bool isChasePlayer;

    private int targetNumber;

    private float distanceToChase = 1;

    private float timeToChangeTarget = 5;

    private Transform target;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = targetList[targetNumber % targetList.Length];
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if(Vector2.Distance(player.position, transform.position) <= distanceToChase)
        {
            agent.SetDestination(player.position);
            return;
        }

        if(isChasePlayer)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(target.position);
        }

        timeToChangeTarget -= Time.deltaTime;

        if (timeToChangeTarget <= 0)
        {
            timeToChangeTarget = 10;
            isChasePlayer = !isChasePlayer;
        }

        if(agent.remainingDistance == 0)
        {
            targetNumber++;
            target = targetList[targetNumber % targetList.Length];
        }
    }

    private void OnDisable()
    {
        transform.position = defaultPosition.position;

        timeToChangeTarget = 5;
        isChasePlayer = false;
        targetNumber = 0;
        target = targetList[targetNumber % targetList.Length];
    }
}
