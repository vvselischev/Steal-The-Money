using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WinLevelState : GameState
{
    public UIManager ui;
    public LevelManager levelManager;
    public Color stringColor;
    public ScoreManager scoreManager;
    public PlayState playState;

    private Level currentLevel;

    public Button exitButton;
    public Button restartButton;

    void Update()
    {
        if (scoreManager.CurrentScore == 60)
        {
            scoreManager.UpdateScore();
            InvokeState();
        }
    }

    public void InvokeState()
    {
        currentLevel = levelManager.CurrentLevel;
        currentLevel.FreezeLevel();
        playState.DeactivatePlayUI();
        ui.PerformLerpString("Completed!", stringColor);

        //scoreManager.UpdateScore();
        StartCoroutine(WaitForSomeSeconds());
        
    }
    
    IEnumerator WaitForSomeSeconds()
    {
        yield return new WaitForSeconds(5);
        currentLevel.DisableLevel();
        ui.DisableText();
        playState.InvokeState();
    }
}