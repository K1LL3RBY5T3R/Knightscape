using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 spawnArea;

    public int maxEnemies = 10;
    public float spawnInterval = 1f;

    private bool canSpawn = false;
    public PlayerHealth playerHealth;


    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(Spawn());
        }
    }

    /*
     * Spawns the enemies with a 1 second delay
     */
    IEnumerator Spawn()
    {
        canSpawn = false;
        for (int i = 0; i < maxEnemies; i++)
        {
            if (playerHealth.GetHasDied())
            {
                // Find all game objects with the "enemy" tag
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                // Loop through each enemy and destroy it
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }
                yield break;
            }
            yield return new WaitForSeconds(1);
            Vector2 randomPosition = GetRandomPositionInSpawnArea();
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
        canSpawn = true;
    }

    /*
     * Gets the random area in which the enemies can spawn
     */
    Vector2 GetRandomPositionInSpawnArea()
    {
        Transform player;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        float randomX = Random.Range(player.position.x - spawnArea.x, player.position.x + spawnArea.x);
        float randomY = Random.Range(player.position.y - spawnArea.y, player.position.y + spawnArea.y);
        GetLimits(randomX);
        GetLimits(randomY);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        return randomPosition;
    }

    /*
     * Gets the limits of the spawn area 
     */
    private float GetLimits(float val)
    {
        if (val < -85)
        {
            return -95;
        }
        if (val > 85)
        {
            return 95;
        }
        return val;
    }

    /*
     * Delays spawning of enemies at start of game
     */
    public IEnumerator StartSpawnDelay()
    {
        yield return new WaitForSeconds(2);
        canSpawn = true;
    }

}
