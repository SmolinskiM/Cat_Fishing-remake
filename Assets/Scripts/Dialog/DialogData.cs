using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog System/Dialog")]
public class DialogData : ScriptableObject
{
    [System.Serializable]
    public class DialogEntry
    {
        public string speaker; // Osoba, kt�ra m�wi
        [TextArea]
        public string text; // Tekst dialogu
    }

    [Header("Dialog Entries")]
    public List<DialogEntry> dialogEntries = new List<DialogEntry>(); // Lista tekst�w dialogowych

    [System.Serializable]
    public class SpeakerSprite
    {
        public string speakerName; // Nazwa osoby
        public Sprite sprite; // Sprite osoby
    }
    public List<SpeakerSprite> speakerSpriteList = new List<SpeakerSprite>(); // Lista speaker�w i ich sprite'�w

    [Header("Next Dialogs")]
    public DialogData nextDialog; // Nast�pny dialog
    public DialogData altDialog; // Alternatywny dialog

    [Header("Button Texts")]
    public string nextButtonText = "Next"; // Tekst na przycisku nextDialog
    public string altButtonText = "Alternative"; // Tekst na przycisku altDialog
}
