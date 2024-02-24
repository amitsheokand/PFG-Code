using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private GameManager _gameManager;
    private Rigidbody2D _rigidbody2D;
    private float JumpForce = 0.4f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void SetGameManager(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    void Update()
    {
        // if player pressed Space key
        // jump the player, so it does not hit other objects
        
        // input

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        
    }

    public void OnCollisionEnter2D (Collision2D other)
    {
        // when we hit ground stop the physics simulation
        if (other.gameObject.name == "Ground")
        {
            _rigidbody2D.simulated = false;
        }

        if (other.gameObject.CompareTag("Damage"))
        {
            _gameManager.GameOver();
        }
    }
}
