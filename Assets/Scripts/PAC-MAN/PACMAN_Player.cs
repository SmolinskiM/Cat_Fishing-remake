using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PACMAN_Player : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private PACMAN_GameManager gameManager;

    private Rigidbody2D rb2d;

    private PlayerAction movement;

    private void Awake()
    {
        movement = new PlayerAction();
        movement.PACMAN.Move.Enable();
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveDirection = movement.PACMAN.Move.ReadValue<Vector2>();
        rb2d.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PACMAN_Ghost>())
        {
            gameManager.LoseGame();
        }
    }
}
