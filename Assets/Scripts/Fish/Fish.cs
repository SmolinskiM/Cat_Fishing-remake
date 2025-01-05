using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fish : MonoBehaviour
{
    public Action OnFishCautch;

    private Transform fishParent;

    private FishData fish;

    private FishSpawner spawnerArea;

    public Transform FishParent { get { return fishParent; } }
    public FishData FishData { get { return fish; } }
    public FishSpawner SpawnerArea { get { return spawnerArea; } set { spawnerArea = value; } }
    public void FishSetup(FishData fish, FishSpawner spawner, Transform fishParent)
    {
        this.fish = fish;
        this.fishParent = fishParent;
        
        spawnerArea = spawner;
        
        if ((int)fish.FishSize == 3)
        {
            transform.localScale *= 1.5f;
        }

        GetComponent<SpriteRenderer>().sprite = fish.FishSprite;
    }

    public void DestoyFish()
    {
        SpawnerArea.FishPool.OnRealease(this);
    }
}
