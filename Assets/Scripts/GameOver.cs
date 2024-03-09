using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver; 
    [SerializeField] private Button gameOverButton;
    [SerializeField] private Timer timer;
    private bool canRestartGame = false;


    // Start is called before the first frame update
    private void Start()
    {
        gameOverButton.onClick.AddListener(ResetGame);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (canRestartGame && Input.anyKeyDown)
        {
            ResetGame();
        }
    }

    /*
     *  Waits 1 second then shows the game over screen
     */
    public IEnumerator GameOverTrigger()
    {
        yield return new WaitForSeconds(1);
        gameOver.SetActive(true); // Activate the GameOverPanel on game over
        canRestartGame = true;
        Time.timeScale = 0f;
    }

    /*
     * Resets the game back to the beginning
     */
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

