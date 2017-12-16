using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayState : MonoBehaviour
{
    public Canvas GameOverCanvas;
    public Canvas playCanvas;

    public UIManager ui;

    public Button exitButton;
    public Button restartButton;
    public GameObject loseImage;
    public LevelManager levelManager;
    public ScoreManager scoreManager;
    public GameOverState gameOverState;

    private void ActivatePlayUI()
    {
        loseImage.SetActive(false);
        GameOverCanvas.enabled = false;
        playCanvas.enabled = true;
        ui.text.enabled = false;
        exitButton.enabled = true;
        restartButton.enabled = true;
    }

    public void DeactivatePlayUI()
    {
        exitButton.enabled = false;
        restartButton.enabled = false;
    }

    public void InitNewGame()
    {
        scoreManager.ResetScore();
    }

    public void RestartGameLevel()
    {
        scoreManager.CurrentScore = 0;
        gameOverState.PreventEndLevel();
        ActivatePlayUI();
        levelManager.RestartLevel();
    }

    public void GameOverButtonPressed()
    {
        levelManager.CurrentLevel.FreezeLevel();
        exitButton.enabled = false;
        gameOverState.InvokeState();
    }

    public void InvokeState()
    {
        ActivatePlayUI();
        levelManager.NextLevel();
    }
}
