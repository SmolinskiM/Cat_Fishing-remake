using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSprite : MonoBehaviour
{
    private FishMovement fishMovement;
    private SpriteRenderer fishSprite;

    private void Start()
    {
        fishMovement = GetComponent<FishMovement>(); 
        fishSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FlipSprite(fishMovement.Target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Hook>())
        {
            if(fishMovement.IsFishOnHook)
            {
                transform.eulerAngles = new Vector3(0, 0, -90);
                fishSprite.flipX = false;
            }
        }
    }

    private void FlipSprite(Vector2 target)
    {
        if(!fishMovement.IsFishOnHook)
        {
            if (target.x < transform.position.x)
            {
                fishSprite.flipX = false;
            }
            else
            {
                fishSprite.flipX = true;
            }
        }
    }
}
