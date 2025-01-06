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
        // Użycie wejścia z klasy FightWithFish
        float input = fightWithFish.InputValue;

        // Obracanie koła wędkarskiego przy użyciu wejścia z FightWithFish
        fishingWheel.transform.Rotate(new Vector3(0, 0, -input * 10));

        // Aktualizacja pozycji UI
        fishUI.localPosition = new Vector3(fightWithFish.FishPosition * 2, 0, 0);
    }
}
