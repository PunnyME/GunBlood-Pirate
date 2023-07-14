using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuUI;

    [SerializeField]
    private GameObject countdownUI;

    [SerializeField]
    private GameObject mainGameUI;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private TextMeshProUGUI countdownText;

    [SerializeField]
    private TextMeshProUGUI playerWinText;

    public void SetGameUI(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Prepare:
                mainMenuUI.SetActive(true);
                countdownUI.SetActive(false);
                mainGameUI.SetActive(false);
                gameOverUI.SetActive(false);
                break;
            case GameState.CountDown:
                mainMenuUI.SetActive(false);
                countdownUI.SetActive(true);
                mainGameUI.SetActive(false);
                gameOverUI.SetActive(false);           
                break;
            case GameState.Playing:
                mainMenuUI.SetActive(false);
                countdownUI.SetActive(false);
                mainGameUI.SetActive(true);
                gameOverUI.SetActive(false);
                break;
            case GameState.GameOver:
                mainMenuUI.SetActive(false);
                countdownUI.SetActive(false);
                mainGameUI.SetActive(false);
                gameOverUI.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void SetCountdownUI(string text)
    {
        countdownText.text = text;
    }

    public void SetPlayerWinUI(string text)
    {
        playerWinText.text = text;
    }
}
