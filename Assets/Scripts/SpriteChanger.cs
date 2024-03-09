using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteChanger : MonoBehaviour
{
    public Sprite spriteIdle;
    public Sprite spriteLeft;
    public Sprite spriteRight;
    public Sprite spriteUp;
    public Sprite spriteDown;

    private SpriteRenderer spriteRenderer;
    private Vector2 lastPosition;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
    }

    private void Update()
    {
        // Get the current movement direction
        Vector2 currentDirection = (Vector2)transform.position - lastPosition;

        // Update the last position for the next frame
        lastPosition = transform.position;

        // Change the sprite based on the movement direction
        if (currentDirection.magnitude > 0.01f)
        {
            if (Mathf.Abs(currentDirection.x) > Mathf.Abs(currentDirection.y))
            {
                // Moving horizontally
                if (currentDirection.x > 0)
                    spriteRenderer.sprite = spriteRight;
                else
                    spriteRenderer.sprite = spriteLeft;
            }
            else
            {
                // Moving vertically
                if (currentDirection.y > 0)
                    spriteRenderer.sprite = spriteUp;
                else
                    spriteRenderer.sprite = spriteDown;
            }
        }
        else
        {
            // Idle state
            spriteRenderer.sprite = spriteIdle;
        }
    }
}