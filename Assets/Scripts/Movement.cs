using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; 
    public SpriteRenderer player;
    public Animator animator;
    private bool isLeft;

    // Start is called before the first frame update
    void Start()
    {
        isLeft = false;
    }


    // Update is called once per frame
    void Update()
    {
        // Get input values for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Move the object based on input and speed
        transform.Translate(movement * speed * Time.deltaTime);
        animator.SetFloat("Speed", Mathf.Abs(movement.magnitude));

        if (horizontalInput < 0 && !isLeft)
        {
            Flip();
        }
        if (horizontalInput > 0 && isLeft)
        {
            Flip();
        }

    }

    /*
     * Flips the direction the player character is looking
     * This code is not written by me and was taken from https://github.com/Brackeys/2D-Animation/blob/master/2D%20Animation/Assets/Scripts/CharacterController2D.cs
     */
    private void Flip()
    {
        isLeft = !isLeft;
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
