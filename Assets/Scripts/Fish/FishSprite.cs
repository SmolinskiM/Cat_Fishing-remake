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
        fishMovement.onCautchFish += FishOnHookSprite;
    }

    private void Update()
    {
        FlipSprite(fishMovement.Target);
    }

    private void FishOnHookSprite()
    {
        transform.eulerAngles = new Vector3(0, 0, 90);
        fishSprite.flipY = true;
    }

    private void FlipSprite(Vector2 target)
    {
        if(fishMovement.IsFishOnHook)
        {
            return;
        }

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
