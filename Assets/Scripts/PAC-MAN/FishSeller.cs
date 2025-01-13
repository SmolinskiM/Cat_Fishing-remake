using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class FishSeller : MonoBehaviour
{
    public Action<PACMAN_GameResult> onGameEnd;

    [SerializeField] private DialogManager dialogManager;

    [SerializeField] private PACMAN_GameManager pACMAN_GameManager;

    [Header("Dialog Options")]
    
    [SerializeField] private DialogData startDialog;
    [SerializeField] private DialogData startGame;
    [SerializeField] private DialogData notEnoughMoney;

    [SerializeField] private DialogData winGame;
    [SerializeField] private DialogData looseGame;

    private PlayerAction fishSellerInteraction;

    private void Awake()
    {
        onGameEnd += GameResult;
    }

    private void Start()
    {
        fishSellerInteraction = new PlayerAction();
        fishSellerInteraction.FishSeller.ClikckOnFishSeller.Enable();
        fishSellerInteraction.FishSeller.ClikckOnFishSeller.performed += ClickOnFishSeller;

        fishSellerInteraction.FishSeller.MousePosition.Enable();
    }

    private void ClickOnFishSeller(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = fishSellerInteraction.FishSeller.MousePosition.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (!hit)
        {
            return;
        }

        if (hit != this)
        {
            return;
        }

        ONClick();
    }

    private void GameResult(PACMAN_GameResult pACMAN_GameResult)
    {
        if(pACMAN_GameResult == PACMAN_GameResult.Win)
        {
            dialogManager.StartDialog(winGame);
        }
        else
        {
            dialogManager.StartDialog(looseGame);
        }
    }

    private void ONClick()
    {
        if(pACMAN_GameManager.isPlayerPlay)
        {
            return;
        }

        //Dialog Start
        dialogManager.onNextButtonClicked += pACMAN_GameManager.StartGame;
        dialogManager.StartDialog(startDialog);
        
    }
}
