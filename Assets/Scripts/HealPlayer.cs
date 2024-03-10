using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private int kills;
    private bool canHeal;
    [SerializeField] private SpriteRenderer heal;

    [SerializeField] private Sprite mySprite; 
    [SerializeField] private float startSizePercentage = 0.5f; 
    [SerializeField] private float endSizePercentage = 0.1f; 
    [SerializeField] private float shrinkTime = 1.0f; 
    [SerializeField] private AudioController audioController;

    // Start is called before the first frame update
    private void Start()
    {
        kills = 0;
        canHeal = false;
    }

    // Update is called once per frame
    private void Update()
    {
        canHealPlayer();
        // Check if the "X" key is pressed
        if (Input.GetKeyDown(KeyCode.X) && canHeal)
        {
            // Perform the healing action
            Potion();
            Heal();
        }
        heal.enabled = canHeal;
    }

    /*
     * Activates the heal action and sets all params to defaults
     */
    private void Heal()
    {
        canHeal = false;
        kills = 0;
        audioController.PlayHealSound();
        playerHealth.Heal();
    }

    /*
     * Creates the game object for the heal action 
     */
    private void Potion()
    {

        float initialSize = Camera.main.orthographicSize * 2 * startSizePercentage;//Sets the size according to a percentage of the screen
        GameObject potion = new GameObject("Potion");
        SpriteRenderer spriteRenderer = potion.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = mySprite;
        spriteRenderer.sortingOrder = 25;// makes it appear above everything
        potion.transform.localScale = new Vector3(initialSize, initialSize, 1f);
        potion.transform.position = Camera.main.transform.position + new Vector3(0, -0.5f, 10f);// sets the position in accorance with the camera

        // Start coroutine to shrink the object over time
        StartCoroutine(ShrinkObject(potion, initialSize, endSizePercentage, shrinkTime));

        // Destroy the object after shrinking and disappear time
        Destroy(potion, shrinkTime + 0.1f);
    }

    /*
     * Shrinks the game object over a time period from starting size to ending size
     */
    private IEnumerator ShrinkObject(GameObject obj, float startSize, float endSize, float duration)
    {
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float progress = Mathf.InverseLerp(startTime, endTime, Time.time);
            float size = Mathf.Lerp(startSize, endSize, progress);
            obj.transform.localScale = new Vector3(size, size, 1f);
            obj.transform.position = Camera.main.transform.position + new Vector3(0, -0.5f, 10f);

            yield return null;
        }
    }

    /*
     * Checks if the player can use the heal action
     */
    public void canHealPlayer()
    {
        if (kills > 10)
        {
            canHeal = true;
        }
    }

    /*
     * Sets the current kill number +1 
     */
    public void setKills()
    {
        kills += 1;
    }
}
