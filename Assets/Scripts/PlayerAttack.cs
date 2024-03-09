using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool canAttack = true;
    public GameObject playerPrefab; 
    public Animator animator;
    [SerializeField] private SpriteRenderer attack;
    [SerializeField] private AudioController audioController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && canAttack)
        {
            SpawnCollider();
            StartCoroutine(DelayAttack());
        }
        attack.enabled = canAttack;
    }

    /*
     * Creates the attack collider to kill enemies 
     * Destroys the collider after a set time
     */
    void SpawnCollider()
    {
        GameObject playerObject = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CircleCollider2D circleCollider = playerObject.GetComponent<CircleCollider2D>();
        if (circleCollider == null)
        {
            return;
        }

        circleCollider.isTrigger = true; 
        AttackCollider attackCollider = playerObject.AddComponent<AttackCollider>();
        Destroy(playerObject, 0.5f);
        audioController.PlayAttackSound();
        StartCoroutine(EndAttack(animator));
    }

    /*
     * Delays when attack can be used again
     */
    IEnumerator DelayAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(1.0f); 
        canAttack = true;
    }

    /*
     * Controls the animation of the attack
     */
    IEnumerator EndAttack(Animator animator)
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f); 
        animator.SetTrigger("Attack");
    }
}
