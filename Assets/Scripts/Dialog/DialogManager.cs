using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private NPCConversation nPCConversation;

    private void Start()
    {
        ConversationManager.Instance.StartConversation(nPCConversation);
    }
}
