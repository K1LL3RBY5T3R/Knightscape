using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 5;

    /*
     * OnCollisionEnter2D is called when two colliders interact
     * This checks if the other collider is of type player and deals damage to the player
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    /*
     * OnCollisionStay2D is called when two colliders interact and stay in contact
     * This checks if the other collider is of type player and deals damage to the player
     */
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
