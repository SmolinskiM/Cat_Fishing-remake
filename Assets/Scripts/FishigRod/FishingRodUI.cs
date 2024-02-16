using UnityEngine;
using UnityEngine.UI;

public class FishingRodUI : MonoBehaviour
{
    [SerializeField] private GameObject powerBarCanvas;

    [SerializeField] private Slider powerBar;

    [SerializeField] private FishingRod fishingRod;

    private void Update()
    {
        if(!fishingRod.IsThrowable)
        {
            powerBarCanvas.SetActive(false);
        }
        else
        {
            powerBarCanvas.SetActive(true);
        }

        powerBar.value = (Time.time - fishingRod.PressTimeStart) / fishingRod.MaxPower;
    }
}
