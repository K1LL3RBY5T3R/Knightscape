using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool canTakeDamage = true;
    private bool died = false;
    public Animator animator;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private AudioController audioController;
    
    // Start is called before the first frame update
    void Start()    
    {
        currentHealth = maxHealth;
    }

    /*
     * Checks if can take damage and then deals damage to the player.
     * When player has no more health calls die
     */
    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {

            currentHealth -= damage;
            // Check if the player is dead
            if (currentHealth <= 0)
            {
                Die();
            }

            // Start the delay coroutine
            StartCoroutine(TakeDamageDelay());
        }
    }

    /*
     * Adds a delay for how long the player can not take damage again after taking damage
     */
    IEnumerator TakeDamageDelay()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1f); // 1-second delay
        canTakeDamage = true;
    }

    /*
     * Triggers the death of the player
     */
    void Die()
    {
        died = true;
        // You can add more functionality here, like restarting the level or showing a game over screen.
        animator.SetTrigger("Death");
        audioController.PlayDeathSound();
        animator.SetTrigger("Death");
        gameOver.StartCoroutine(gameOver.GameOverTrigger());
    }

    /*
     * Heals the player by a percentage of total health
     */
    public void Heal()
    {
        if (currentHealth < maxHealth - 10)
        {
            currentHealth += 10;
        }
        else
        {
            currentHealth = maxHealth;
        }
    }

    /*
     * Sets the new value for canTakeDamage
     */
    public void SetCanTakeDamage(bool canTakeDamage)
    {
        this.canTakeDamage = canTakeDamage;
    }

    /*
     * Returns the bool died
     */
    public bool GetHasDied()
    {
        return died;
    }
}