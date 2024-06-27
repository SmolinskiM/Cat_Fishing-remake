using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PACMAN_Player : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private PACMAN_GameManager gameManager;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PACMAN_Ghost>())
        {
            gameManager.LoseGame();
        }
    }
}
