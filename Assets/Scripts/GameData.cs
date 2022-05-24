using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public string PlayerName;
    public string HighscorePlayer;
    public int Highscore;
    public static GameData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else Destroy(gameObject);
    }

    public void NewScore(int score)
    {
        if (score > Highscore)
        {
            Highscore = score;
            HighscorePlayer = PlayerName;
            SaveData();
        }
    }

    [System.Serializable]
    class Data
    {
        public string PlayerName;
        public string HighscorePlayer;
        public int Highscore;
    }

    private void SaveData()
    {
        Data data = new Data();

        data.PlayerName = PlayerName;
        data.HighscorePlayer = HighscorePlayer;
        data.Highscore = Highscore;

        string json_data = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/gamedata.json", json_data);
    }

    private void LoadData()
    {
        string path = Application.persistentDataPath + "/gamedata.json";

        if (File.Exists(path))
        {
            string json_data = File.ReadAllText(path);

            Data data = JsonUtility.FromJson<Data>(json_data);

            PlayerName = data.PlayerName;
            HighscorePlayer = data.HighscorePlayer;
            Highscore = data.Highscore;
        }
    }
}
