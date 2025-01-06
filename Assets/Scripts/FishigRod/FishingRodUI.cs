using UnityEngine;
using UnityEngine.UI;

public class FishingRodUI : MonoBehaviour
{
    [SerializeField] private GameObject powerBarCanvas;
    [SerializeField] private Slider powerBar;
    [SerializeField] private FishingRod fishingRod;

    private void OnEnable()
    {
        fishingRod.OnThrowableChanged += HandleThrowableChanged;
    }

    private void OnDisable()
    {
        fishingRod.OnThrowableChanged -= HandleThrowableChanged;
    }

    private void Update()
    {
        if (powerBarCanvas.activeSelf)
        {
            // Aktualizuje wartość paska mocy
            float currentPower = (Time.time - fishingRod.PressTimeStart) / fishingRod.MaxPower;
            powerBar.value = Mathf.Clamp01(currentPower);
        }
    }

    private void HandleThrowableChanged(bool isThrowable)
    {
        // Włącza lub wyłącza widoczność paska mocy
        powerBarCanvas.SetActive(isThrowable);
    }
}
