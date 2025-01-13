using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog System/Dialog")]
public class DialogData : ScriptableObject
{
    [System.Serializable]
    public class DialogEntry
    {
        public string speaker; // Osoba, która mówi
        [TextArea]
        public string text; // Tekst dialogu
    }

    [Header("Dialog Entries")]
    public List<DialogEntry> dialogEntries = new List<DialogEntry>(); // Lista tekstów dialogowych

    [System.Serializable]
    public class SpeakerSprite
    {
        public string speakerName; // Nazwa osoby
        public Sprite sprite; // Sprite osoby
    }
    public List<SpeakerSprite> speakerSpriteList = new List<SpeakerSprite>(); // Lista speakerów i ich sprite'ów

    [Header("Next Dialogs")]
    public DialogData nextDialog; // Nastêpny dialog
    public DialogData altDialog; // Alternatywny dialog

    [Header("Button Texts")]
    public string nextButtonText = "Next"; // Tekst na przycisku nextDialog
    public string altButtonText = "Alternative"; // Tekst na przycisku altDialog
}
