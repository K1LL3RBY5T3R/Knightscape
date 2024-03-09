using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    /*
     * OnTriggerEnter2D is called when the collider comes in contact with another collider
     * Checks if the other collider is an enemy and destroys the enemy if true
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        { 
            Destroy(other.gameObject);
        }
    }
}
