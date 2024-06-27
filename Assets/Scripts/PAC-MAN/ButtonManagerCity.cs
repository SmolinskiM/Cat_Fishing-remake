using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerCity : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private FishData fishData;
    [SerializeField] private UnityEngine.UI.Button backToFishing;

    private void Awake()
    {
        backToFishing.onClick.AddListener(Back);

        if (sceneIndex != 1)
        {
            return;
        }

        if (FishSaveMeneger.Instance.fishSave.fishDictiosnary.Count == 0)
        {
            backToFishing.gameObject.SetActive(false);
            return;
        }

        backToFishing.gameObject.SetActive(FishSaveMeneger.Instance.fishSave.fishDictiosnary["GoldFish"]);
    }

    private void Back()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
