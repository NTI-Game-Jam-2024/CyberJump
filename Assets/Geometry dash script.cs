using UnityEngine;

public class Geometrydashscript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move diagonally up and to the right
        Vector2 movement = new Vector2(moveSpeed, moveSpeed);

        // Change y-direction when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.y *= -1;
        }

        rb.velocity = movement;
    }
}
