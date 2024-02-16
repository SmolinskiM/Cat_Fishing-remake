using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Bait bait;
    [SerializeField] private GameObject water;
    [SerializeField] private Transform positionRod;
    
    private bool isHookOnRod;
    private bool isFishOnHook;
    private bool isHookInWater;
    private int rollingUpSpeed;

    private DistanceJoint2D joint;
    
    private Rigidbody2D rb;

    public bool IsHookOnRod { get { return isHookOnRod; } set { isHookOnRod = value; } }
    public bool IsFishOnHook { get { return isFishOnHook; } set { isFishOnHook = value; } }
    public bool IsHookInWater { get { return isHookInWater; } }

    public Bait Bait { get { return bait; } }
    public DistanceJoint2D Joint { get { return joint; } }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
    }

    private void Update()
    {
        if(isHookInWater)
        {
            if (bait.BaitSize == 0 && !isFishOnHook && !isHookOnRod)
            {
                rollingUpSpeed = 20;
                RollingUp(rollingUpSpeed);
                return;
            }

           if (bait.BaitSize != 0 && !isFishOnHook && Input.GetKey(KeyCode.Mouse0) && !isHookOnRod)
           {
                rollingUpSpeed = 10;
                RollingUp(rollingUpSpeed);
                return;
           }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(water.tag))
        {
            isHookInWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(water.tag))
        {
            transform.position = positionRod.position;
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.freezeRotation = true;
            isHookOnRod = true;
            isHookInWater = false;

        }
    }

    public void RollingUp(float rollingUpSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, positionRod.position, rollingUpSpeed * Time.deltaTime);
        joint.distance -= rollingUpSpeed * Time.deltaTime;
    }
}
