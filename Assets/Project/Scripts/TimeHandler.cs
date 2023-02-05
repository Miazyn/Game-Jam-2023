using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{

    private int globalTime = 0;
    private bool keepCounting = true;
    public GameObject prefab;
    public GameObject tree;

    public delegate void TimeHasChangedCallback();
    public TimeHasChangedCallback timeChangeCallback;


    void Start()
    {
        StartCoroutine(GlobalTimeHandler());
        StartCoroutine(EnemySpawing());
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

    IEnumerator EnemySpawing()
    {
        while (true)
        {
            for (int i = Random.Range(5, 10); i > 0 ; i--)
            {
                GameObject thing = spawnEnemy();
                thing.GetComponent<Enemy>().tree = this.tree;
            }

            yield return new WaitForSeconds(15);
        }
        
        
    }

    GameObject spawnEnemy()
    {
        return Instantiate(prefab, spawnCoordsVector(), Quaternion.identity);
    }
    private Vector3 spawnCoordsVector()
    {
        float y = Random.Range(0f, 10f);
        float x = Mathf.Sqrt(Mathf.Pow(10f, 2)-Mathf.Pow(y, 2));
        return new Vector3(x, y, 1);
    }
}
