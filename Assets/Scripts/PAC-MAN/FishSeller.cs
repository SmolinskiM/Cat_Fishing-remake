using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSeller : MonoBehaviour
{
    [SerializeField] private NPCConversation npcConversation;

    [SerializeField] private PACMAN_GameManager pACMAN_GameManager;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                if(hit == this)
                {
                    ONClick();
                }
            }
        }
    }

    private void ONClick()
    {
        if(pACMAN_GameManager.isPlayerPlay)
        {
            return;
        }

        if(ConversationManager.Instance.IsConversationActive)
        {
            return;
        }

        ConversationManager.Instance.StartConversation(npcConversation);
        
    }
}
