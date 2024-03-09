using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffects;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip blockSound;
    [SerializeField] private AudioClip playerDeathSound;

    /*
     * Plays the attack sound
     */
    public void PlayAttackSound()
    {
        soundEffects.PlayOneShot(attackSound);
    }

    /*
     * Plays the heal sound
     */
    public void PlayHealSound()
    {
        soundEffects.PlayOneShot(healSound);
    }

    /*
     * Plays the block sound
     */
    public void PlayBlockSound()
    {
        soundEffects.PlayOneShot(blockSound);
    }

    /*
     * Plays the death sound
     */
    public void PlayDeathSound()
    {
        soundEffects.PlayOneShot(playerDeathSound);
    }
}
