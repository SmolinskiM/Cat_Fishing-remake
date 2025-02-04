using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog System/Dialog")]
public class DialogData : ScriptableObject
{
    [System.Serializable]
    public class DialogEntry
    {
        public string speaker;
        [TextArea]
        public string text;
    }

    [Header("Dialog Entries")]
    public List<DialogEntry> dialogEntries = new List<DialogEntry>();

    [System.Serializable]
    public class SpeakerSprite
    {
        public string speakerName;
        public Sprite sprite;
    }
    public List<SpeakerSprite> speakerSpriteList = new List<SpeakerSprite>();

    [Header("Next Dialogs")]
    public DialogData nextDialog;
    public DialogData altDialog;

    [Header("Button Texts")]
    public string nextButtonText = "Next";
    public string altButtonText = "Alternative";
}
