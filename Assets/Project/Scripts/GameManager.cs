using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
}
