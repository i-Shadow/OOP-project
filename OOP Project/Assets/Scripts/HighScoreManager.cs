using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScores";
    public List<HighScoreEntry> highScores = new List<HighScoreEntry>();

    private void Awake()
    {
        LoadHighScores();
    }

    public void AddHighScore(string name, int score)
    {
        HighScoreEntry newEntry = new HighScoreEntry { name = name, score = score };
        highScores.Add(newEntry);
        highScores.Sort((x, y) => y.score.CompareTo(x.score));

        if (highScores.Count > 10)
        {
            highScores.RemoveRange(10, highScores.Count - 10);
        }

        SaveHighScores();
    }

    private void SaveHighScores()
    {
        string json = JsonUtility.ToJson(new HighScoreList { scores = highScores });
        PlayerPrefs.SetString(HighScoreKey, json);
        PlayerPrefs.Save();
    }

    private void LoadHighScores()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            string json = PlayerPrefs.GetString(HighScoreKey);
            HighScoreList loadedScores = JsonUtility.FromJson<HighScoreList>(json);
            highScores = loadedScores.scores;
        }
    }

    [System.Serializable]
    private class HighScoreList
    {
        public List<HighScoreEntry> scores;
    }
}
