using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{
    [SerializeField] private int baitSizeStart;
    
    private int baitSize;

    public int BaitSizeStart { get { return baitSizeStart; } set { baitSizeStart = value; } }

    public int BaitSize { get { return baitSize; } }

    void Start()
    {
        ChangeSizeBait(baitSizeStart);
    }

    public void ChangeSizeBait(int baitSize)
    {
        this.baitSize = baitSize;
        BaitSprite.Instance.ChangeBaitSprite(baitSize);
    }
}
