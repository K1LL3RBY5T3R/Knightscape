using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Score score;
    private HealPlayer healPlayer;
    private GameObject gameController;
    private EnemySoundController enemySoundController;
    private GameObject soundController;

    // Awake is called once the script is created
    private void Awake()
    {
        gameController = GameObject.Find("GameController");
        soundController = GameObject.Find("EnemySFX");
        healPlayer = gameController.GetComponent<HealPlayer>();
        score = gameController.GetComponent<Score>();
        enemySoundController = soundController.GetComponent<EnemySoundController>();
    }

    /* 
     * OnDestroy is called when the object is destroyed
     * This updates the kills and score and plays the death sound for the enemy
     */
    private void OnDestroy()
    {
        healPlayer.setKills();
        score.SetScoreValue();
        enemySoundController.PlayDeathSound();
    }
}
