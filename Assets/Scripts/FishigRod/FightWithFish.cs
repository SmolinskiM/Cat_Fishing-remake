using UnityEngine;

public class FightWithFish : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private GameObject figthCanvas;
    
    private Fish fish;
    private int direction;
    private readonly float moveSpeedFishUI = 50;
    private float fishPosition = 0;
    private float cooldown = 2;

    private const float MOVE_SPEED = 15;
    private const float FAST_AREA = 20;
    private const float BREAK_AREA = 80;

    public float FishPosition { get { return fishPosition; } }

    private void Update()
    {
        if (hook.IsFishOnHook && !hook.IsHookOnRod)
        {
            fish = hook.GetComponentInChildren<Fish>();
            Fight();
            figthCanvas.SetActive(true);
        }
        else
        {
            fishPosition = 0;
            figthCanvas.SetActive(false);
        }
    }

    private void Fight()
    {
        if(Mathf.Abs(FishPosition) <= FAST_AREA)
        {
            hook.RollingUp(MOVE_SPEED * 1.5f);
        }
        else
        {
            hook.RollingUp(MOVE_SPEED);
        }

        if(Mathf.Abs(FishPosition) >= BREAK_AREA)
        {
            FishMovement fishMovment;

            fishMovment = hook.GetComponentInChildren<FishMovement>();
            hook.IsFishOnHook = false;
            fishMovment.IsFishOnHook = false;
            fishMovment.transform.eulerAngles = Vector3.zero;
            fishMovment.transform.parent = fishMovment.Area;
        }

        if (Time.time >= cooldown)
        {
            cooldown = Time.time + 2;
            direction = Random.Range(0, 2) * 2 - 1;
        }

        fishPosition += (moveSpeedFishUI * (int)fish.FishData.FishSize * direction) * Time.deltaTime;
        fishPosition += Input.GetAxis("Horizontal") * 200 * Time.deltaTime;
    }
}
