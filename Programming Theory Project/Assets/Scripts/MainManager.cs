using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public int colorNumber;
    public int environmentNumber;
    public int modeNumber;
    public int stageNumber;

    public bool oneWay;
    public bool twoWay;

    public int onewayHighscoreEndLess;
    public int twowayHighscoreEndLess;
    public int onewayHighscoreTimeTrial;
    public int twowayHighscoreTimeTrial;


    public static MainManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public int colorNumber;
        public int onewayHighscoreEndLess;
        public int twowayHighscoreEndLess;
        public int onewayHighscoreTimeTrial;
        public int twowayHighscoreTimeTrial;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.colorNumber = colorNumber;
        data.onewayHighscoreEndLess = onewayHighscoreEndLess;
        data.twowayHighscoreEndLess = twowayHighscoreEndLess;
        data.onewayHighscoreTimeTrial = onewayHighscoreTimeTrial;
        data.twowayHighscoreTimeTrial = twowayHighscoreTimeTrial ;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            colorNumber = data.colorNumber;
            onewayHighscoreEndLess = data.onewayHighscoreEndLess;
            twowayHighscoreEndLess= data.twowayHighscoreEndLess;
            onewayHighscoreTimeTrial = data.onewayHighscoreTimeTrial;
            twowayHighscoreTimeTrial= data.twowayHighscoreTimeTrial;
        
        }
    }
}
