using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PACMAN_Points : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PACMAN_Player>())
        {
            Destroy(gameObject);
        }
    }
}
