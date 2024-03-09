using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject hudUI;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Button startButton;
    [SerializeField] private SpawnEnemies spawnEnemies;

    // Start is called before the first frame update
    void Start()
    {
        hudUI.SetActive(false);
        Time.timeScale = 0f; // Pause everything 
        musicSource.playOnAwake = true; // Ensure music starts automatically
        startButton.onClick.AddListener(StartGame); // Add a listener to the button click event
    }

    /*
     * Starts tje game and shows the HUD
     */
    public void StartGame()
    { 
        Time.timeScale = 1f;// Unpause the 
        startMenuUI.SetActive(false);// Hide the Start Menu UI
        hudUI.SetActive(true);
        spawnEnemies.StartCoroutine(spawnEnemies.StartSpawnDelay()); //Starts the delay of enemy spawning at start of game
    }
}
