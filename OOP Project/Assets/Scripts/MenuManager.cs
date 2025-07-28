using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject highScorePanel;
    public TextMeshProUGUI highScoreText;

    private HighScoreManager highScoreManager;

    private void Start()
    {
        highScoreManager = FindObjectOfType<HighScoreManager>();
        if (highScoreManager != null)
        {
            UpdateHighScoreText();
        }
    }

    public void StartGame()
    {
        if (nameInputField.text != "")
        {
            PlayerPrefs.SetString("PlayerName", nameInputField.text);
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Player name is required");
        }
    }

    public void SetScore()
    {
        gameOverPanel.SetActive(true);
        scoreText.text = "Score: " + (int)GameManager.Instance.score;
        highScoreManager.AddHighScore(PlayerPrefs.GetString("PlayerName"), (int)GameManager.Instance.score);
        UpdateHighScoreText();
    }

    public void ShowHighScorePanel()
    {
        highScorePanel.SetActive(true);
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "";
        foreach (var score in highScoreManager.highScores)
        {
            highScoreText.text += score.name + ": " + score.score + "\n";
        }
    }
}
