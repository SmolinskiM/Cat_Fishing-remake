using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private FishData fish;

    public FishData FishData { get { return fish; } }

    public void FishSetup(FishData fish, Transform spawner)
    {
        this.fish = fish;
        transform.parent = spawner;
        if ((int)fish.FishSize == 3)
        {
            transform.localScale *= 1.5f;
        }

        GetComponent<SpriteRenderer>().sprite = fish.FishSprite;
    }
}
