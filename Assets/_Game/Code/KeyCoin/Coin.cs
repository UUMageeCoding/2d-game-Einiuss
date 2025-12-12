using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private float coinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coin trigger hit by: " + collision.name);
        {
            if (collision.tag == "Player")
            {
                var key = collision.GetComponent<Key>();
                Debug.Log("Key component found? " + (key != null));

                if (key != null)
                    key.AddCoin(coinValue);
                gameObject.SetActive(false);
            }
        }
    }


}
