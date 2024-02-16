using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : SingletoneMonobehaviour<FishingRod>
{
    [SerializeField] private Hook hook;
    [SerializeField] private Transform pointRod;
    [SerializeField] private Transform pointHook;
    [SerializeField] private ShopOpen shopOpen;
    [SerializeField] private OpenCatalogManager catalogMeneger;

    [SerializeField] private Rigidbody2D hookRb;

    private bool isThrowable;
    private float pressTimeStart;
    private float maxDistance = 70;
    private LineRenderer lr;
    
    private const float MAX_POWER = 5;
    private const float MIN_DISTANCE = 4;
    
    public float MaxPower { get { return MAX_POWER; } }
    public bool IsThrowable { get { return isThrowable; } }
    public float PressTimeStart { get { return pressTimeStart; } }
    public float MaxDistance { get { return maxDistance; } set { maxDistance = value; } }
    public Hook Hook { get { return hook; } }

    private new void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Start()
    { 
        hook.IsHookOnRod = true;
    }

    private void Update()
    {
        EnableTrowHook();
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void EnableTrowHook()
    {
        if(shopOpen.IsShopOpen)
        {
            isThrowable = false;
            return;
        }

        if(catalogMeneger.IsCatalogOpen)
        {
            isThrowable = false;
            return;
        }

        if (hook.IsHookOnRod && !hook.IsFishOnHook)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                pressTimeStart = Time.time;
                isThrowable = true;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0) && isThrowable)
            {
                if (hook.Bait.BaitSize == 0)
                {
                    hook.Bait.ChangeSizeBait(hook.Bait.BaitSizeStart);
                }
                TrowHook(Time.time - PressTimeStart);
                pressTimeStart = 0;
                isThrowable = false;
                hook.IsHookOnRod = false;
            }
        }
    }

    private void TrowHook(float power)
    {
        if (power > MAX_POWER)
        {
            power = MAX_POWER;
        }
        hook.Joint.distance = (power / MAX_POWER) * maxDistance;

        if(hook.Joint.distance < 4)
        {
            hook.Joint.distance = MIN_DISTANCE;
        }

        hookRb.gravityScale = 1;
        hookRb.AddForce(new Vector2(300, 100) * power);
    }

    private void DrawRope()
    {
        lr.SetPosition(0, pointRod.position);
        lr.SetPosition(1, pointHook.position);
    }
}
