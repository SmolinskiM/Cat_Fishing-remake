using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private Fish fish;
    
    private bool isFishOnHook;

    private bool isReachPoint = true;
    private float targetPositionX;
    private float targetPositionY;
    
    private Transform area;
    private Vector2 target;
    
    private const int RANGE = 10;
    private const int FISHSPEED = 10;
    
    public bool IsFishOnHook { get { return isFishOnHook; } set { isFishOnHook = value; } }
    public Vector2 Target { get { return target; } }
    public Transform Area { get { return area; } }

    private void Start()
    {
        hook = FindObjectOfType<Hook>();
        fish = GetComponent<Fish>();
        area = transform.parent;
    }

    private void Update()
    {
        if (isFishOnHook)
        {
            return;
        }

        if (transform.position == new Vector3(targetPositionX, targetPositionY, transform.position.z))
        {
            isReachPoint = true;
        }

        if (isReachPoint)
        {
            targetPositionX = Random.Range(area.transform.position.x - area.transform.localScale.x / 2, area.transform.position.x + area.transform.localScale.x / 2);
            targetPositionY = Random.Range(area.transform.position.y - area.transform.localScale.y / 2, area.transform.position.y + area.transform.localScale.y / 2);
            isReachPoint = false;
        }

        float distanceToBait = Vector2.Distance(transform.position, hook.transform.position);

        if(distanceToBait <= RANGE && hook.Bait.BaitSize != 0 && hook.IsHookInWater)
        {
            target = hook.transform.position;
        }
        else
        {
            target = new Vector2(targetPositionX, targetPositionY);
        }

        PointToFishTravel(target);
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
                isFishOnHook = true;
            }
            hook.Bait.ChangeSizeBait(0);
        }
    }

    private void PointToFishTravel(Vector2 target)
    { 
        transform.position = Vector2.MoveTowards(transform.position, target, FISHSPEED * Time.deltaTime);
    }
}
