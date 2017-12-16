using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverState : MonoBehaviour
{

    public UIManager ui;
    public Canvas gameOverCanvas;
    private Level currentLevel;
    public LevelManager levelManager;
    public Color stringColor;
    public ScoreManager scoreManager;
     
    public Button exitButton;
    public Button restartButton;

    public GameObject loseImage;

    private bool needToOver;

    public void PreventEndLevel()
    {
        needToOver = false;
        StopAllCoroutines();
    }

    void Start()
    {
        gameOverCanvas.enabled = false;
        loseImage.SetActive(false);
    }

    public void InvokeState()
    {
        currentLevel = levelManager.CurrentLevel;
        ui.PerformLerpString("GameOver!", stringColor);

        currentLevel.FreezeLevel();
        needToOver = true;

        StartCoroutine(WaitForSomeSeconds());
    }

    IEnumerator WaitForSomeSeconds()
    {
        yield return new WaitForSeconds(5);

        if (needToOver)
        {
            needToOver = false;
            currentLevel.DisableLevel();
            ui.DisableText();
            ui.DisableAll();
            loseImage.SetActive(true);
            gameOverCanvas.enabled = true;


            //scoreManager.ViewScore();
        }
        else
        {
            //yield break;
        }
    }
}
