using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hook : MonoBehaviour
{
    public Action onHookBackToRodFree;

    [SerializeField] private Bait bait;
    [SerializeField] private GameObject water;
    [SerializeField] private Transform positionRod;

    private bool isHookOnRod;
    private bool isFishOnHook;
    private bool isHookInWater;

    private int rollingUpSpeed;

    private DistanceJoint2D joint;
    private Rigidbody2D rb;

    private PlayerAction playerActions;

    public bool IsHookOnRod { get { return isHookOnRod; } set { isHookOnRod = value; } }
    public bool IsFishOnHook { get { return isFishOnHook; } set { isFishOnHook = value; } }
    public bool IsHookInWater { get { return isHookInWater; } }
    public Bait Bait { get { return bait; } }
    public DistanceJoint2D Joint { get { return joint; } }

    private void Awake()
    {
        playerActions = new PlayerAction();
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
    }

    private void Update()
    {
        if (!isHookInWater) return;

        if (!isFishOnHook && !isHookOnRod)
        {
            rollingUpSpeed = bait.BaitSize == 0 ? 20 : 10;

            if (rollingUpSpeed == 20 || playerActions.Rod.RollingUp.ReadValue<float>() > 0)
            {
                RollingUp(rollingUpSpeed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(water.tag)) { isHookInWater = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(water.tag)) { ResetHookPosition(); }
    }

    private void ResetHookPosition()
    {
        transform.position = positionRod.position;
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.freezeRotation = true;

        isHookOnRod = true;
        isHookInWater = false;

        if(!isFishOnHook)
        {
            onHookBackToRodFree?.Invoke();
        }

    }

    public void RollingUp(float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, positionRod.position, speed * Time.deltaTime);
        joint.distance = Mathf.Max(0, joint.distance - speed * Time.deltaTime);
    }
}
