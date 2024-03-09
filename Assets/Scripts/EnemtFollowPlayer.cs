using UnityEngine;

public class EnemtFollowPlayer : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            GetComponent<Rigidbody2D>().velocity = direction * Random.Range(2f, 5f); // Move towards the player
        }
    }
}
