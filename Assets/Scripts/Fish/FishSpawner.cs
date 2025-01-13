using NavMeshPlus.Components;
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

    [SerializeField] private Transform fishParent;

    private bool isGoldenFishSpawned;

    private int fishToSpawnGold;

    private ObjectPool<Fish> fishPool;

    public bool IsPossibleToSpawnGoldFish { get { return isPossibleToSpawnGoldFish; } set { isPossibleToSpawnGoldFish = value; } }
    public ObjectPool<Fish> FishPool { get {  return fishPool; } }

    private void Awake()
    {
        fishPool = new ObjectPool<Fish>(fishPrefab, transform);
        fishPool.OnRealeaseObject += DecideWhatFishSpawn;
    }

    private void Start()
    {
        for(int i = 0; i < fishMax; i++)
        {
            DecideWhatFishSpawn();
        }
    }

    public void DecideWhatFishSpawn()
    {

        int fishRandom = Random.Range(0, fish.Length);

        foreach(FishData fishData in fish)
        {
            if(fishData == goldFish)
            {
                isGoldenFishSpawned = true;
                break;
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
        Fish fishNew = fishPool.OnTake(); 
        fishNew.transform.position = new Vector3(positionX, positionY, 0);
        fishNew.FishSetup(fishData, this, fishParent);
    }
}
