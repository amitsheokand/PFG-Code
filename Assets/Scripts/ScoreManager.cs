using System.Collections;
using System.Collections.Generic;
using NCU;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private GameManager _gameManager;

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
}
