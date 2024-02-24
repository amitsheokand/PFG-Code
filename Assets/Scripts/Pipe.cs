using System;
using System.Collections;
using System.Collections.Generic;
using NCU;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private GameManager _gameManager;
    private float speed = 0.5f;

    private float minX = -2.25f;
    private float maxX = 2.25f;

    private bool autoDelete = false;

    private void Awake()
    {
    }


    void Update()
    {
        if(_gameManager.gameState != GameState.Playing)
            return;
        
        if (!autoDelete)
        {
            // we want our x property to go from
            // 1.75 -> -1.75
            float newXpos = transform.position.x - Time.deltaTime * speed;

            if (newXpos < minX)
            {
                // Delete this pipe (self)
                if (_gameManager != null)
                {
                    // create new pipe
                    _gameManager.GenerateNewPipe();

                    autoDelete = true;
                    Destroy(this.gameObject);
                }
            }
            else
            {
                transform.position = new Vector3(newXpos, transform.position.y, 0);
            }
        }
    }

    public void Begin(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
}
