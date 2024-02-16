using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Fish")]
public class FishData : ScriptableObject
{
    [SerializeField] private int value;

    [SerializeField] private FishSize fishSize;
    [SerializeField] private Vector3 ofset;
    [SerializeField] private Sprite fishSprite;

    public int Value { get { return value; } }

    public FishSize FishSize { get { return fishSize; } }
    public Vector3 Ofset { get { return ofset; } }
    public Sprite FishSprite { get { return fishSprite; } }
}

[CreateAssetMenu(fileName = "FishList", menuName = "FishList")]
public class FishDataList : ScriptableObject
{
    [SerializeField] private List<FishData> fishDatas;

    public List<FishData> FishDatas { get { return fishDatas; } }
}

