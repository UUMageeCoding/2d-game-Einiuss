using UnityEngine;

public class bouncePad : MonoBehaviour
{
    public float bounceforce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerBounce(collision.gameObject);
        }
    }

    private void PlayerBounce(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            //reset player vertical velocity
            rb.AddForce(Vector2.up * bounceforce, ForceMode2D.Impulse);
            //apply upward force
            SoundEffectManager.Play("Bounce");
        }
    }

}
