using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public Action onCautchFish;
    private enum FishState { Swimming, ChasingBait, Caught }
    private FishState currentState;

    [SerializeField] private Hook hook;
    [SerializeField] private Fish fish;

    private Transform swimmingArea;
    private Vector2 target;

    private const int RANGE = 10;
    private const int FISHSPEED = 10;

    public bool IsFishOnHook { get; set; }
    public Vector2 Target { get { return target; } }


    private void Start()
    {
        hook = FindObjectOfType<Hook>();
        fish = GetComponent<Fish>();
        swimmingArea = fish.SpawnerArea.transform;
        currentState = FishState.Swimming;
        SetNewTarget();
    }

    private void OnEnable()
    {
        IsFishOnHook = false;
    }

    private void Update()
    {
        switch (currentState)
        {
            case FishState.Swimming:
                Swim();
                CheckForBait();
                break;
            case FishState.ChasingBait:
                ChaseBait();
                break;
            case FishState.Caught:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Hook>())
        {
            if (hook.Bait.BaitSize >= (int)fish.FishData.FishSize)
            {
                transform.parent = hook.transform;
                transform.position = hook.transform.position + fish.FishData.Ofset;
                hook.IsFishOnHook = true;
                currentState = FishState.Caught;
                onCautchFish?.Invoke();
            }
            hook.Bait.ChangeSizeBait(0);
        }
    }

    private void Swim()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, FISHSPEED * Time.deltaTime);

        if ((Vector2)transform.position == target)
        {
            SetNewTarget();
        }
    }

    private void CheckForBait()
    {
        float distanceToBait = Vector2.Distance(transform.position, hook.transform.position);

        currentState = FishState.Swimming;

        if (!hook.IsHookInWater)
        {
            return;
        }

        if(hook.Bait.BaitSize == 0)
        {
            return;
        }

        if (distanceToBait > RANGE )
        {
            return;
        }
        
        currentState = FishState.ChasingBait;
    }

    private void ChaseBait()
    {
        transform.position = Vector2.MoveTowards(transform.position, hook.transform.position, FISHSPEED * Time.deltaTime);

        if (Vector2.Distance(transform.position, hook.transform.position) > RANGE || hook.Bait.BaitSize == 0 || !hook.IsHookInWater)
        {
            currentState = FishState.Swimming;
        }
    }

    private void SetNewTarget()
    {
        target = new Vector2(
            UnityEngine.Random.Range(swimmingArea.position.x - swimmingArea.localScale.x / 2, swimmingArea.position.x + swimmingArea.localScale.x / 2),
            UnityEngine.Random.Range(swimmingArea.position.y - swimmingArea.localScale.y / 2, swimmingArea.position.y + swimmingArea.localScale.y / 2)
        );
    }
}