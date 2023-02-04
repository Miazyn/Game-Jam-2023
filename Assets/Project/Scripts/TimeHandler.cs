using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{

    private int globalTime = 0;
    private bool keepCounting = true;

    public delegate void TimeHasChangedCallback();
    public TimeHasChangedCallback timeChangeCallback;


    void Start()
    {
        StartCoroutine(GlobalTimeHandler());
    }

    public int getGlobalTimeSeconds()
    {
        return globalTime;
    }

    public string getGlobalTimeSecondsFormated()
    {
        int _currentTime = getGlobalTimeSeconds();
        int minutes = _currentTime / 60;
        int seconds = _currentTime % 60;

        string textReturn = string.Format("{0:00}:{1:00}", minutes, seconds);

        return textReturn;

        //return minutes.ToString() + " : " + seconds.ToString();
    }

    public void setKeepCounting(bool _keepCounting)
    {
        keepCounting = _keepCounting;
    }

    public void setGlobalTimeSeconds(int _newGlobalTimeSeconds)
    {
        globalTime = _newGlobalTimeSeconds;
    }

    IEnumerator GlobalTimeHandler()
    {
        Debug.Log("Starting global time handler");
        while (true)
        {
            if (!keepCounting)
            {
                Debug.Log("Skipped time increase");
                continue;
            }
            globalTime = globalTime + 1;

            timeChangeCallback?.Invoke();

            yield return new WaitForSeconds(1);
        }
    }
}
