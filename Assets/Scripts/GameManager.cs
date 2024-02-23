using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private Player _player;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnedGameObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        _player = spawnedGameObject.GetComponent<Player>();
        
        Debug.Log($"player is this {_player.name}, after spawning in scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
