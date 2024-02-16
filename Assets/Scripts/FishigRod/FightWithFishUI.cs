using UnityEngine;

public class FightWithFishUI : MonoBehaviour
{
    [SerializeField] private FightWithFish fightWithFish;
    [SerializeField] private Transform fishingWheel;
    
    private RectTransform fishUI;

    private void Start()
    {
        fishUI = GetComponent<RectTransform>();
    }

    private void Update()
    {
        fishingWheel.transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal") * 10));
        fishUI.localPosition = new Vector3(fightWithFish.FishPosition * 2, 0, 0);
    }

}
