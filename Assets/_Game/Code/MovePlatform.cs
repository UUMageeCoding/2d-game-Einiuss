using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float movementDistance = 3f;
    [SerializeField] private float speed = 2f;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        rb.bodyType = RigidbodyType2D.Kinematic;

        //calculates both boundaries and sets the platform to kinematic so code can move it
    }

    private void FixedUpdate()
    {
        float x = transform.position.x;

        if (movingLeft)
        {
            if (x > leftEdge) x -= speed * Time.fixedDeltaTime;
            else movingLeft = false;
        }
        else
        {
            if (x < rightEdge) x += speed * Time.fixedDeltaTime;
            else movingLeft = true;

            //movement of the platform
        }

        rb.MovePosition(new Vector2(x, rb.position.y));
    }
}
