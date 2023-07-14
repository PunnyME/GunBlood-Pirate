using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Prepare,
    CountDown,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private string player1WinText = "Player1 Win!";
    private string player2WinText = "Player2 Win!";

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private PlayerController player1;

    [SerializeField]
    private PlayerController player2;

    [SerializeField]
    private int countdownTime = 3;

    private GameState oldGameState;
    private GameState gameState;

    void Start()
    {
        oldGameState = GameState.Prepare;
        gameState = GameState.Prepare;
        uiManager.SetGameUI(gameState);
    }

    void Update()
    {
        if (gameState == GameState.Prepare || gameState == GameState.GameOver)
        {
            if (Input.GetButtonDown("Start"))
            {
                GameStateChange(GameState.CountDown);
                StartCoroutine(CountdownUI());
            }
        }
        else if (gameState == GameState.Playing)
        {
            if (Input.GetButtonDown("Player1Fire"))
            {
                player1.FireBullet();
                GameOver(player1WinText);
            }

            else if (Input.GetButtonDown("Player2Fire"))
            {
                player2.FireBullet();
                GameOver(player2WinText);
            }
        }
    }

    private IEnumerator CountdownUI()
    {
        int currentCountdownTime = countdownTime;

        while (currentCountdownTime > 0f)
        {
            uiManager.SetCountdownUI(currentCountdownTime.ToString());
            yield return new WaitForSeconds(1f);
            currentCountdownTime--;
        }

        GameStart();
    }

    private void GameStateChange(GameState currentState)
    {
        gameState = currentState;
        uiManager.SetGameUI(gameState);
        if (oldGameState != gameState)
        {
            oldGameState = gameState;
        }
    }

    public void GameStart()
    {
        GameStateChange(GameState.Playing);
    }

    public void GameOver(string playerWinText)
    {
        GameStateChange(GameState.GameOver);
        uiManager.SetPlayerWinUI(playerWinText);
    }
}
