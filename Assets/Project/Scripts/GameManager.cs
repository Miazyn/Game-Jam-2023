using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public int resourceOne { get; private set; }

    public GameState CurGameState { get; private set; }

    public enum GameState
    {
        StartPhase,
        WaveDefense,
        DownTime
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        resourceOne = 0;
    }

    public void ChangeGameState(GameState _gameState)
    {
        CurGameState = _gameState;

        CheckGameStateLogic();
    }

    private void CheckGameStateLogic()
    {
        switch (CurGameState)
        {
            case GameState.StartPhase:
                break;
            case GameState.WaveDefense:
                break;
            case GameState.DownTime:
                break;
            default:
                Debug.LogError("Unexpected Game State occured!");
                break;
        }

    }

    
    public void AddResource(int _addedAmount)
    {
        resourceOne += _addedAmount;
    }
}
