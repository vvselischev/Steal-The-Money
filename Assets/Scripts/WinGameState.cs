using UnityEngine;
using UnityEngine.UI;

public class WinGameState : MonoBehaviour
{
    public Canvas gameOverCanvas;

    public LevelManager levelManager;
    public PlayState playState;
    public ScoreManager scoreManager;

    public Button restartButton;
    public Button exitButton;

    public Text finalScoreText;
    public Text highScoreText;
    public Text scoreText2;
    public Text scoreText3;

    public GameObject winImage;

    void Start()
    {
        gameOverCanvas.enabled = false;
        winImage.SetActive(false);
    }

    public void InvokeState()
    {
        gameOverCanvas.enabled = true;
        winImage.SetActive(true);
        restartButton.enabled = true;
        exitButton.enabled = true;
        finalScoreText.enabled = true;
        highScoreText.enabled = true;
        scoreText2.enabled = true;
        scoreText3.enabled = true;

        finalScoreText.text = scoreManager.finalScoreText.text;
        highScoreText.text = scoreManager.highScoreText.text;
         
        //scoreManager.ViewScore();
    }

    public void RestartGame()
    {
        winImage.SetActive(false);
        restartButton.enabled = false;
        exitButton.enabled = false;
        finalScoreText.enabled = false;
        highScoreText.enabled = false;
        scoreText2.enabled = false;
        scoreText3.enabled = false;
        exitButton.enabled = false;
        levelManager.InitNewGame();
        scoreManager.ResetScore();
        playState.InvokeState();
    }
}
