using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FishSaveMeneger : SingletoneMonobehaviour<FishSaveMeneger>
{
    [System.Serializable]
    public class FishSaveHandrel
    {
        public List<string> fishName;
        public List<bool> fishStatus;
    }

    [System.Serializable]
    public class FishSave
    {
        public Dictionary<string, bool> fishDictiosnary = new Dictionary<string, bool>();
    }

    public FishSave fishSave = new FishSave();
    public FishSaveHandrel fishSaveHandrel = new FishSaveHandrel();

    [SerializeField] private FishDataList fishDataList;
    
    private readonly FileHandrel<FishSaveHandrel> fileHandrel = new FileHandrel<FishSaveHandrel>();
    private string savePath;

    private new void Awake()
    {
        savePath = Application.dataPath + "/Save/FishSave.json";

        if (File.Exists(savePath))
        {
            LoadData();
        }
        else
        {
            foreach(FishData fish in fishDataList.FishDatas)
            {
                fishSave.fishDictiosnary.Add(fish.name, false);
            }
        }
    }

    public void SaveData(FishData fish)
    {
        fishSave.fishDictiosnary[fish.name] = true;

        fishSaveHandrel.fishName.Clear();
        fishSaveHandrel.fishStatus.Clear();
        foreach(KeyValuePair<string, bool> fishSave in fishSave.fishDictiosnary)
        {
            fishSaveHandrel.fishName.Add(fishSave.Key);
            fishSaveHandrel.fishStatus.Add(fishSave.Value);
        }

        fileHandrel.SaveData(savePath, fishSaveHandrel);
    }

    private void LoadData()
    {
        fishSave.fishDictiosnary.Clear();

        fishSaveHandrel.fishName = fileHandrel.LoadData(savePath).fishName;
        fishSaveHandrel.fishStatus = fileHandrel.LoadData(savePath).fishStatus;

        for (int i = 0; i < fishSaveHandrel.fishName.Count; i++)
        {
            fishSave.fishDictiosnary.Add(fishSaveHandrel.fishName[i], fishSaveHandrel.fishStatus[i]);
        }
    }
}
