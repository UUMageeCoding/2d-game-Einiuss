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
            //if there is a wall, wall is set to be active

            collision.transform.position = startPoint.position;
            //teleports player back to start point when they pickup coin
        }

    }
}