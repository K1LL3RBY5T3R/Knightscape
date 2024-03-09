using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{

    private bool canBlock = true;
    public Animator animator;
    public PlayerHealth playerHealth;
    [SerializeField] private SpriteRenderer block;
    [SerializeField] private AudioController audioController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && canBlock)
        {
            StartCoroutine(BlockDamage(animator));
            StartCoroutine(BlockDelay());
        }

        block.enabled = canBlock;
    }

    /*
     * Blocks all damage to play for 0.5 seconds and triggers the animation
     */
    IEnumerator BlockDamage(Animator animator)
    {
        playerHealth.SetCanTakeDamage(false);
        animator.SetTrigger("Block");
        audioController.PlayBlockSound();
        yield return new WaitForSeconds(0.5f); 
        playerHealth.SetCanTakeDamage(true);
        animator.SetTrigger("Block");
    }

    /*
     * Sets a delay on when block can be used again
     */
    IEnumerator BlockDelay()
    {
        canBlock = false;
        yield return new WaitForSeconds(5f); 
        canBlock = true;
    }
}
