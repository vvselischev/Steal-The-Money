using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int currentScore;
    private int highScore;

    private const string highScoreFilePath = "STMHighScore.txt";

    public FileManager fileManager;
    public Text scoreText;
    public Text highScoreText;
    public Text finalScoreText;

    public void InvokeManager()
    {
        scoreText.enabled = true;
    }

    void Start()
    {
        scoreText.enabled = false;

        finalScoreText.text = "0";
        highScoreText.text = "0";

        //fileManager = FileManager.GetInstance();
        //fileManager.CreateIfNotExist(highScoreFilePath);
        // int? tmpHighScore = fileManager.ReadFromFile(highScoreFilePath);
        /* if (tmpHighScore != null)
         {
             HighScore = (int)tmpHighScore;
         }
         else
         {
             HighScore = 0;
         }*/
        HighScore = 0;
    }

    public void UpdateScore()
    {
        score += currentScore;
        CurrentScore = 0;
    }

    private void UpdateHighScore()
    {
        //fileManager.RewriteIntInFile(highScore, highScoreFilePath);
        highScoreText.text = HighScore.ToString();
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            scoreText.text = "Score: " + (score + currentScore).ToString();
            if (score > highScore)
            {
                HighScore = score;
            }
        }
    }

    public void ResetScore()
    {
        Score = 0;
        CurrentScore = 0;
    }

    public int GetTotalScore()
    {
        return score + currentScore;
    }

    public int HighScore
    {
        get
        {
            return highScore;
        }
        private set
        {
            highScore = value;
            UpdateHighScore();
        }
    }

    public int CurrentScore
    {
        get
        {
            return currentScore;
        }

        set
        {
            currentScore = value;
            scoreText.text = "Score: " + (score + currentScore).ToString();
            if (score + currentScore > highScore)
            {
                HighScore = score + currentScore;
            }
        }
    }

    public void AddScore(int value)
    {
        CurrentScore += value;
        scoreText.text = "Score: " + GetTotalScore().ToString();
        finalScoreText.text = GetTotalScore().ToString();
    }
}