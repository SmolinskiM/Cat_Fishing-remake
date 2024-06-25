using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private bool isPossibleToSpawnGoldFish;
    
    [SerializeField] private int fishMax;

    [SerializeField] private FishData[] fish;
    [SerializeField] private Fish fishPrefab;

    [SerializeField] private FishData goldFish;

    [SerializeField] private NPCConversation NPCConversation;

    private bool isGoldenFishSpawned;
    
    private int fishCurrent;
    private int fishToSpawnGold;

    public bool IsPossibleToSpawnGoldFish { get { return isPossibleToSpawnGoldFish; } set { isPossibleToSpawnGoldFish = value; } }

    private void Update()
    {
        fishCurrent = transform.childCount;

        if (fishCurrent < fishMax)
        {
            DecideWhatFishSpawn();
        }
    }

    private void DecideWhatFishSpawn()
    {
        int fishRandom = Random.Range(0, fish.Length);

        foreach(FishData fishData in fish)
        {
            if(fishData == goldFish)
            {
                isGoldenFishSpawned = true;
            }
        }

        if(!isPossibleToSpawnGoldFish)
        {
            SpawnFish(fish[fishRandom]);
            fishToSpawnGold--;
            return;
        }

        if (fishToSpawnGold <= 0 && !isGoldenFishSpawned)
        {
            SpawnFish(goldFish);
            fishToSpawnGold = 50;

            return;
        }

        SpawnFish(fish[fishRandom]);
        fishToSpawnGold--;
    }    

    private void SpawnFish(FishData fishData)
    {
        float positionX = Random.Range(gameObject.transform.position.x - gameObject.transform.localScale.x / 2, gameObject.transform.position.x + gameObject.transform.localScale.x / 2);
        float positionY = Random.Range(gameObject.transform.position.y - gameObject.transform.localScale.y / 2, gameObject.transform.position.y + gameObject.transform.localScale.y / 2);
        
        Fish fishNew = Instantiate(fishPrefab, new Vector3(positionX, positionY, 0), Quaternion.identity);
        fishNew.FishSetup(fishData, transform);
    }
}
