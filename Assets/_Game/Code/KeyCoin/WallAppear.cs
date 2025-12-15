using UnityEngine;

public class WallAppear : MonoBehaviour
{

    [SerializeField] private GameObject Wall;
    [SerializeField] private Transform startPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Wall != null)
                Wall.SetActive(true);

            collision.transform.position = startPoint.position;
        }

    }
}