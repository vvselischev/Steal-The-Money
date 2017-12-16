using UnityEngine;
using System.Collections;
using System;

public class Level : MonoBehaviour
{
    public Safe safe;
    public GameObject coins;
    public Hole hole;
    public TimerManager timerManager;
    public int levelDurationSec = 100;
    public int scoreForCoin = 10;
    public ScoreManager scoreManager;
    public CoinList coinList;
    public WinLevelState winLevelState;

    private bool paused;
    private int coinsCount;


    void Start()
    {
        hole.onDrop += coinDropped;
    }

    private void coinDropped(object sender, EventArgs e)
    {
        coinList.RemoveCoin(sender as GameObject);
        scoreManager.AddScore(scoreForCoin);
        coinsCount--;
        /*if (coinsCount == 0)
            winLevelState.InvokeState(); */           
    }

    public void StartLevel()
    {
        gameObject.SetActive(true);
        safe.Activate();
        safe.ResetRotation();
        hole.Activate();

        coins.SetActive(true);
        coinList.Initialize();
        coinList.ResetCoins();
        coinsCount = coinList.TotalCoinsCount;

        scoreManager.scoreText.enabled = true;
        
        timerManager.timeText.enabled = true;
        timerManager.StartTimer(levelDurationSec);
    }

    public void Initialize()
    {
        //safe.Initialize();
        //DisableLevel();
        gameObject.SetActive(false);
    }

    public void UnfreezeLevel()
    {
        paused = false;
        hole.Activate();
        //timerManager.StopTimer();
        safe.GetComponent<Rotator>().enabled = false;
    }

    public void FreezeLevel()
    {
        paused = true;
        hole.Deactivate();
        timerManager.StopTimer();
        safe.SetRotationAvailable(false);

    }

    public void DisableLevel()
    {
        if (!paused)
            FreezeLevel();
        safe.Deactivate();
        coins.SetActive(false);
    }
}
