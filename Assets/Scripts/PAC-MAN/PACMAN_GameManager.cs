using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PACMAN_GameManager : MonoBehaviour
{
    [SerializeField] private Transform pointHolder;

    [SerializeField] private Transform pointHolderBackup;

    [SerializeField] private Transform player;

    [SerializeField] private Transform playerPosition;

    [SerializeField] private GameObject Game;

    [SerializeField] private NPCConversation win;

    [SerializeField] private NPCConversation loose;

    public bool isPlayerPlay;

    private void Update()
    {
        if(pointHolder.childCount == 0)
        {
            WinGame();
        }
    }

    private void OnDisable()
    {
        player.position = playerPosition.position;
        PACMAN_Points[] pointList = pointHolderBackup.GetComponentsInChildren<PACMAN_Points>();

        foreach(PACMAN_Points PACMAN_Point in pointList)
        {
            Instantiate(PACMAN_Point, pointHolder);
        }
    }

    public void StartGame()
    {
        isPlayerPlay = true;
        Game.SetActive(true);
    }

    public void LoseGame()
    {
        isPlayerPlay = false;
        Game.SetActive(false);
        ConversationManager.Instance.StartConversation(loose);
    }    

    private void WinGame()
    {
        isPlayerPlay = false;
        Game.SetActive(false);
        ConversationManager.Instance.StartConversation(win);
    }
}
