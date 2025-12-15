using UnityEngine;
using System.Collections;

public class FallingPlayform : MonoBehaviour
{
    public float fallWait = 2f;
    public float DestroyWait = 1f;

    bool isFalling;
    Rigidbody2D rb;
    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFalling && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    { 
    isFalling = true;
        yield return new WaitForSeconds(fallWait);
        rb.bodyType = RigidbodyType2D.Dynamic;
        //Destroy(gameObject, DestroyWait);
        yield return new WaitForSeconds(DestroyWait);
        RespawnPlatform();
    }
    private void RespawnPlatform()
    {
        isFalling = false;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = startPosition;
    }
}
