using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Canvas dialogCanvas;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private TextMeshProUGUI displayedText;
    [SerializeField] private Image speakerImage;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button altButton;
    [SerializeField] private TextMeshProUGUI nextDialogText;
    [SerializeField] private TextMeshProUGUI altDialogText;

    private DialogData currentDialog;
    private int currentEntryIndex = 0;

    [Header("Events")]
    public Action onNextButtonClicked;
    public Action onAltButtonClicked;

    private void Start()
    {
        // Przypisanie zdarzeñ przycisków
        nextButton.onClick.AddListener(NextDialog);
        altButton.onClick.AddListener(AltDialog);
    }

    public void StartDialog(DialogData dialog)
    {
        if (dialog == null)
        {
            Debug.LogWarning("Dialog data is null!");
            return;
        }

        currentDialog = dialog;
        currentEntryIndex = 0;
        UpdateUI();
        dialogCanvas.gameObject.SetActive(true);
    }

    private void UpdateUI()
    {
        if (currentDialog == null || currentDialog.dialogEntries.Count == 0)
        {
            Debug.LogWarning("No dialog entries to display!");
            return;
        }

        var entry = currentDialog.dialogEntries[currentEntryIndex];
        displayedText.text = entry.text;

        Sprite sprite = GetSpeakerSprite(entry.speaker);
        speakerImage.sprite = sprite;
        speakerImage.enabled = sprite != null;

        bool hasNextDialog = currentDialog.nextDialog != null;
        bool hasAltDialog = currentDialog.altDialog != null;

        nextDialogText.text = hasNextDialog ? currentDialog.nextButtonText : "End";
        nextButton.gameObject.SetActive(true);

        if (hasAltDialog)
        {
            altDialogText.text = currentDialog.altDialog.altButtonText;
            altButton.gameObject.SetActive(true);
        }
        else
        {
            altButton.gameObject.SetActive(false);
        }
    }

    private Sprite GetSpeakerSprite(string speakerName)
    {
        foreach (var speakerSprite in currentDialog.speakerSpriteList)
        {
            if (speakerSprite.speakerName == speakerName)
                return speakerSprite.sprite;
        }
        return null;
    }

    public void NextDialog()
    {
        if (currentDialog == null) return;

        if (currentEntryIndex < currentDialog.dialogEntries.Count - 1)
        {
            currentEntryIndex++;
            UpdateUI();
        }
        else if (currentDialog.nextDialog != null)
        {
            onNextButtonClicked?.Invoke();
            ClearEvents();
            StartDialog(currentDialog.nextDialog);
        }
        else
        {
            onNextButtonClicked?.Invoke();
            EndDialog();
        }
    }

    public void AltDialog()
    {
        if (currentDialog == null || currentDialog.altDialog == null) return;

        onAltButtonClicked?.Invoke();
        ClearEvents();
        StartDialog(currentDialog.altDialog);
    }

    private void EndDialog()
    {
        Debug.Log("Ending dialog");
        dialogCanvas.gameObject.SetActive(false);
        displayedText.text = "End";
        speakerImage.sprite = null;
        speakerImage.enabled = false;
    }

    private void ClearEvents()
    {
        onAltButtonClicked = null;
        onNextButtonClicked = null;
    }
}
