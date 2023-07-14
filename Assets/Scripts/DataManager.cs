using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static DataManager instance;
    public string highScoreName;
    public string playerName;
    public int highScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class SaveDatas
    {
        public string highScoreName;
        public string playerName;
        public int highScore;

    }

    public void SaveData()
    {
        SaveDatas data = new SaveDatas();
        data.highScoreName = highScoreName;
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDatas data = JsonUtility.FromJson<SaveDatas>(json);

            highScoreName = data.highScoreName;
            playerName = data.playerName;
            highScore = data.highScore;
        }
    }
}
