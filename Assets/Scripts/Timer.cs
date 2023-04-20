using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerTxt;
    private float startTime;
    private bool isRunning;
    private index_tiles Game;

    void Start()
    {
        startTime = Time.time;
        isRunning = true;
        Game = GetComponent<index_tiles>();
    }

    void Update()
    {
        if (isRunning)
        {
            float elapsedTime = Time.time - startTime;
            int minutes = Convert.ToInt32(elapsedTime / 60f);
            int seconds = Convert.ToInt32(elapsedTime % 60f);
            
            string timeStr = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerTxt.text = timeStr;

            if (Game.finish)
            {
                StopTimer();
            }
        }

    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
