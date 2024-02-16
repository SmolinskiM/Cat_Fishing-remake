using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCatalogSlot : MonoBehaviour
{
    [SerializeField] private FishDataList fishDataList;
    [SerializeField] private Slot slotPrefab;
    [SerializeField] private Transform content;

    private void Awake()
    {
        foreach (FishData fish in fishDataList.FishDatas)
        {
            Slot slotNew = Instantiate(slotPrefab, content.position, Quaternion.identity, content);
            slotNew.SetUpSlot(fish);
        }
    }
}
