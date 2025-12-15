using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    [SerializeField] private Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform startPoint;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {


            spriteRenderer.sprite = newSprite;
            collision.transform.position = startPoint.position;
        }

    }
}
