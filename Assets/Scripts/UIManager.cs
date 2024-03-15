using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameManager))]
public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    public RectTransform MainMenuUI;
    public RectTransform InGameUI;
    public RectTransform GameOverUI;

    public RectTransform leaderboardUi;
    public TMP_Text highScoreText;

    private void Awake()
    {
        MainMenuUI.gameObject.SetActive(true);
        leaderboardUi.gameObject.SetActive(false);
        
        gameManager = gameObject.GetComponent<GameManager>();
    }

    #region MainMenu

    public void OnPlayPressed()
    {
        Debug.Log("Play Pressed");
        
        MainMenuUI.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(true);
        
        gameManager.OnGameBegins();
    }
    
    public void OnLeaderboardPressed()
    {
        Debug.Log("Leaderboard Pressed");
        leaderboardUi.gameObject.SetActive(true);
    }

    #endregion MainMenu

    #region GameOver

    public void OnRestartPressed()
    {
        Debug.Log("On restart pressed");

        gameManager.Cleanup();
        
        MainMenuUI.gameObject.SetActive(true);
        InGameUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
    }
    
    public void ShowGameOver()
    {
        InGameUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(true);
    }

    #endregion GameOver


   
}
