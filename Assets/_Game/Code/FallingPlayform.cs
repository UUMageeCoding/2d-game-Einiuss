using UnityEngine;
using System.Collections;

public class FallingPlayform : MonoBehaviour
{
    public float fallWait = 2f;
    public float DestroyWait = 1f;

    bool isFalling;
    Rigidbody2D rb;
    private Vector3 startPosition;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        startPosition = transform.position;
        //get platform position
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFalling && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
            //when player land on it, platform will start falltimer
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
        //enables falling platform and wait timer for platform to respawn
    }
    private void RespawnPlatform()
    {
        isFalling = false;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = startPosition;
        //respawns the platform in its original place
    }
}
