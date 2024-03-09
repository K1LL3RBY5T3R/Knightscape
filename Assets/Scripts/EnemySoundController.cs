using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    [SerializeField] AudioClip deathNoise;
    [SerializeField] AudioSource audioSource;
    [SerializeField] PlayerHealth playerHealth;

    /*
     * Plays the death sound for the enemy on their death
     */
    public void PlayDeathSound()
    {
        if (!playerHealth.GetHasDied())
        {
            audioSource.PlayOneShot(deathNoise); 
        }
    }
}
