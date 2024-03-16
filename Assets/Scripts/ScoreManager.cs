using System.Collections;
using System.Collections.Generic;
using NCU;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private GameManager _gameManager;

    public static readonly string ScoreKey = "HighScore";
    
    private float startTime = 0;

    private int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        
        // get the start time
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.gameState == GameState.Playing)
        {
            // score is current time - start time
            score = (int)(Time.time - startTime);

            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }
    }

    public void SaveScore()
    {
        // score

        if (PlayerPrefs.HasKey(ScoreKey))
        {
            
            // get saved score

            int _savedScore =PlayerPrefs.GetInt(ScoreKey);

            if (_savedScore < score)
            {
                PlayerPrefs.SetInt(ScoreKey, score);
                PlayerPrefs.Save();
            }
            
        }
        else
        {
            // first time
            // save current score
            PlayerPrefs.SetInt(ScoreKey, score);
            PlayerPrefs.Save();
        }

        score = 0;
        startTime = Time.time;
    }
}
