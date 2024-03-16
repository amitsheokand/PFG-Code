using UnityEngine;
using NCU;
using Random = UnityEngine.Random;


[RequireComponent(typeof(UIManager))]
public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform playerSpawnPosition;
    public GameObject pipePrefab;

    public UIManager uiManager;
    public ScoreManager scoreManager;

    public AudioSource audioSource;
    
    private Player _player;
    public GameState gameState;



    // private List<GameObject> pipes = new List<GameObject>();

    private void Awake()
    {
        uiManager = gameObject.GetComponent<UIManager>();
    }


    public void OnGameBegins()
    { 
        gameState = GameState.Playing; 
        SetUp();
    }

    private void SetUp()
    {
        GameObject spawnedPlayer = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);
        _player = spawnedPlayer.GetComponent<Player>();
        _player.SetGameManager(this);
        
        GameObject spawnedCenterPipeObject = Instantiate(pipePrefab, new Vector3(0.5f, 0, 0), Quaternion.identity);
        Pipe _centerPipe = spawnedCenterPipeObject.GetComponent<Pipe>();
        _centerPipe.Begin(this);
        
        GameObject spawnedCenterPipeObject2 = Instantiate(pipePrefab, new Vector3(2.25f, 0, 0), Quaternion.identity);
        Pipe _centerPipe2 = spawnedCenterPipeObject2.GetComponent<Pipe>();
        _centerPipe2.Begin(this);
      
        
        GenerateNewPipe();
    }


    public void GenerateNewPipe()
    {
        Vector3 randomPipePosition = new Vector3(4f, Random.Range(-1.0f, 1.0f), 0);
        
        GameObject spawnedPipeObject = Instantiate(pipePrefab, randomPipePosition, Quaternion.identity);
        Pipe _pipe = spawnedPipeObject.GetComponent<Pipe>();

        _pipe.Begin(this);
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        uiManager.ShowGameOver();
        scoreManager.SaveScore();
        Debug.Log("Game Over!");
        
        audioSource.Play();
    }

    public void Cleanup()
    {
        GameObject.Destroy(_player.gameObject);

        var pipes = GameObject.FindObjectsByType<Pipe>(FindObjectsSortMode.None);

        foreach (var pipe in pipes)
        {
            GameObject.Destroy(pipe.gameObject);
        }
    }
}
