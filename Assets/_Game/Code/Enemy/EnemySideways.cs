using UnityEngine;

public class EnemySideways : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        //calculate left and right boundaries
    }


    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }

            else
            {
                movingLeft = false;
            }
        }
        else 
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }

            else
            {
                movingLeft = true;
            }
        }

        //switching direction of movement when each boundary is reached
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { if (collision.tag == "Player")
        {
            SoundEffectManager.Play("Damage");
            collision.GetComponent<Health>().TakeDamage(damage);
        }

    //if object touching player, player takes damage
    }
}
