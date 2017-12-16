using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimerManager : MonoBehaviour
{
    public Text timeText;
    private int secondsLeft;
    private bool started;
    private long timeInStart;

    public GameOverState gameOverState;

    public void StartTimer(int duration)
    {
        secondsLeft = duration;
        started = true;
        
        timeInStart = DateTime.Now.ToBinary() / 10000000;
    }

    void Update()
    {
        if (started)
        {
            timeText.text = (secondsLeft + timeInStart - DateTime.Now.ToBinary() / 10000000).ToString();
            if (secondsLeft + timeInStart - DateTime.Now.ToBinary() / 10000000 <= 0)
            {
                StopTimer();
                gameOverState.InvokeState();
            }
        }
    }

    public void StopTimer()
    {
        started = false;
    }

    public void Reset()
    {
        secondsLeft = 0;
        timeText.text = "0";
    }
}
