using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels = new List<Level>();

    private int startLevel = -1;
    public WinGameState winGameState;
    public GameOverState gameOverState;

    [HideInInspector]
    public Level CurrentLevel
    {
        get
        {
            return levels[startLevel];
        }
    }

    public void InitializeLevels()
    {
        foreach (Level level in levels)
        {
            level.Initialize();
        }
    }

    public void RestartLevel()
    {
        startLevel--;
        NextLevel();
    }

    public void InitNewGame()
    {
        startLevel = -1;
    }

    public void NextLevel()
    {
        startLevel++;
        if (startLevel < levels.Count)
        {
            levels[startLevel].StartLevel();
        }
        else
        {
            winGameState.InvokeState();
        }
    }
}
