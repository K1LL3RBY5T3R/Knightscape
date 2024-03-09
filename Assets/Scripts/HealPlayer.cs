using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private int kills;
    private bool canHeal;
    [SerializeField] private SpriteRenderer heal;

    [SerializeField] private Sprite mySprite; // Use SerializeField for inspector access
    [SerializeField] private float startSizePercentage = 0.5f; // Initial size as percentage
    [SerializeField] private float endSizePercentage = 0.1f; // Final size as percentage
    [SerializeField] private float shrinkTime = 1.0f; // Time to shrink
    [SerializeField] private AudioController audioController;

    private void Start()
    {
        kills = 0;
        canHeal = false;
    }

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

    private void Heal()
    {
        canHeal = false;
        kills = 0;
        // Add your healing logic here
        // For example, increase player's health

        // Replace the following line with your actual healing logic
        // For example, increase player's health variable or call a healing function
        audioController.PlayHealSound();
        playerHealth.Heal();
    }

    private void Potion()
    {

        float initialSize = Camera.main.orthographicSize * 2 * startSizePercentage;
        GameObject potion = new GameObject("Potion");
        SpriteRenderer spriteRenderer = potion.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = mySprite;
        spriteRenderer.sortingOrder = 25;
        potion.transform.localScale = new Vector3(initialSize, initialSize, 1f);
        potion.transform.position = Camera.main.transform.position + new Vector3(0, -0.5f, 10f);

        // Start coroutine to shrink the object over time
        StartCoroutine(ShrinkObject(potion, initialSize, endSizePercentage, shrinkTime));

        // Destroy the object after shrinking and disappear time
        Destroy(potion, shrinkTime + 0.1f);
    }

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
    public void canHealPlayer()
    {
        if (kills > 10)
        {
            canHeal = true;
        }
    }

    public void setKills()
    {
        kills += 1;
    }
}
