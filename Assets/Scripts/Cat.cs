using UnityEngine;

public class Cat : MonoBehaviour
{
    public new string name = "Kitty";
    public int age = 3;
    public float speed = 5.0f;
    private Rigidbody2D rb;

    private void Meow()
    {
        Debug.Log("Meow!");
    }

    private void Scratch()
    {
        Debug.Log("Scratch!");
    }

    void Start()
    {
        Meow();

        // Check if Rigidbody2D exists, if not, add it
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        // Explicitly disable gravity regardless of whether we added the component or it already existed
        rb.gravityScale = 0;
        rb.freezeRotation = true; // Or use rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        float horizontalInput = 0;
        float verticalInput = 0;

        if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1;
        if (Input.GetKey(KeyCode.UpArrow)) verticalInput = 1;
        if (Input.GetKey(KeyCode.DownArrow)) verticalInput = -1;

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        Vector2 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
