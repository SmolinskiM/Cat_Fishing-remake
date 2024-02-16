using UnityEngine;

public class BaitSprite : SingletoneMonobehaviour<BaitSprite>
{
    [SerializeField] private Sprite[] baitSprite;
    
    private Hook hook;
    private SpriteRenderer bait;

    private void Start()
    {
        hook = GetComponentInParent<Hook>();
        bait = GetComponent<SpriteRenderer>();
    }

    public void ChangeBaitSprite(int baitSize)
    {
        if (baitSize == 0)
        {
            bait.sprite = null;
            return;
        }

        if (baitSize < baitSprite.Length)
        {
            bait.sprite = baitSprite[hook.Bait.BaitSize - 1];
            return;
        }

        bait.sprite = baitSprite[baitSprite.Length - 1];
    }
}
