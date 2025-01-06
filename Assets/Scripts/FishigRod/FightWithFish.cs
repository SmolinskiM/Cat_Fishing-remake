using UnityEngine;

public class FightWithFish : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private GameObject figthCanvas;
    [SerializeField] private Transform navMesh;

    private Fish fish;
    private int direction;
    private readonly float moveSpeedFishUI = 50;
    private float fishPosition = 0;
    private float cooldown = 2;

    private const float MOVE_SPEED = 15;
    private const float FAST_AREA = 20;
    private const float BREAK_AREA = 80;

    private PlayerAction moveAction;

    public float FishPosition { get { return fishPosition; } }

    public float InputValue { get; private set; }  // Nowa publiczna właściwość dla wejścia

    private void OnEnable()
    {
        moveAction = new PlayerAction();
        moveAction.Rod.FightWithFish.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

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

        // Zapisanie wartości wejściowej do publicznej właściwości
        InputValue = moveAction.Rod.FightWithFish.ReadValue<float>();
    }

    private void Fight()
    {
        if (Mathf.Abs(FishPosition) <= FAST_AREA)
        {
            hook.RollingUp(MOVE_SPEED * 1.5f);
        }
        else
        {
            hook.RollingUp(MOVE_SPEED);
        }

        if (Mathf.Abs(FishPosition) >= BREAK_AREA)
        {
            FishMovement fishMovement;

            fishMovement = hook.GetComponentInChildren<FishMovement>();
            hook.IsFishOnHook = false;
            fishMovement.IsFishOnHook = false;
            fishMovement.transform.eulerAngles = Vector3.zero;
            fishMovement.transform.parent = navMesh;
        }

        if (Time.time >= cooldown)
        {
            cooldown = Time.time + 2;
            direction = Random.Range(0, 2) * 2 - 1;
        }

        fishPosition += (moveSpeedFishUI * (int)fish.FishData.FishSize * direction) * Time.deltaTime;
        fishPosition += InputValue * 200 * Time.deltaTime;
    }
}
