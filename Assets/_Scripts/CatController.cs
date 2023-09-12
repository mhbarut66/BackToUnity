using UnityEngine;

public class CatController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 250f;
    private Rigidbody2D rb;
    private float movement;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the cat to the mouse
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Move the cat in the direction of the mouse
        movement = direction.x;

        // Check if the cat is moving left
        if (movement < 0)
        {
            // Rotate the cat to face left
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        // Check if the cat is moving right
        else if (movement > 0)
        {
            // Rotate the cat to face right
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            // Make the cat jump
            rb.velocity = new Vector2(0, jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
