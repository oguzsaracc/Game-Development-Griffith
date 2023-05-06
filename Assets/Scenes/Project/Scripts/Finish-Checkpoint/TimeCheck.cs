using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCheck : MonoBehaviour
{
    public float timeStart = 0;
    public bool timeRunning = true;
    public TMP_Text textTime;

    // Start is called before the first frame update
    void Start()
    {
        timeRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRunning)
        {
            if (timeStart >= 0)
            {
                timeStart += Time.deltaTime;
                timeDisplay(timeStart);
            }
        }
    }

    void timeDisplay(float displayTime)
    {
        displayTime += 1;
        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);
        float milliseconds = Mathf.FloorToInt((displayTime - Mathf.Floor(displayTime)) * 1000f);
        textTime.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void StopTime()
    {
        timeRunning = false;
    }

    public void DisplayTime()
    {
        timeDisplay(timeStart);
    }
}
