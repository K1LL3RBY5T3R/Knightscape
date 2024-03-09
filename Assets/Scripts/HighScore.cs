using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText; 
    private int currentHighScore;
    private string highScoreFilePath;
    [SerializeField] private Score score;
    private int currentScore;

    void Start()
    {
        highScoreFilePath = Application.persistentDataPath + "/highScore.txt";
        if (!File.Exists(highScoreFilePath))
        {
            File.CreateText(highScoreFilePath).Close(); 
        }
        LoadHighScore();
        UpdateHighScoreText();
    }

    void Update()
    {
        currentScore = score.GetScoreValue();
        if (currentScore > currentHighScore)
        {
            currentHighScore = currentScore;
            SaveHighScore();
            UpdateHighScoreText();
        }
    }

    void LoadHighScore()
    {
        if (File.Exists(highScoreFilePath))
        {
            try
            {
                string highScoreString = File.ReadAllText(highScoreFilePath);
                int.TryParse(highScoreString, out currentHighScore);
            }
            catch (IOException e)
            {
                Debug.LogError("Error loading high score: " + e.Message);
                currentHighScore = 0; 
            }
        }
        else
        {

            currentHighScore = 0;
        }
    }

    void SaveHighScore()
    {
        try
        {
            File.WriteAllText(highScoreFilePath, currentHighScore.ToString());
        }
        catch (IOException e)
        {
            Debug.LogError("Error saving high score: " + e.Message);
        }
    }

    void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + currentHighScore.ToString("N0");
        }
    }
}
