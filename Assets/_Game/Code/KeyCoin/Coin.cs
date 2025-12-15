using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private float coinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.tag == "Player")
            {
                var key = collision.GetComponent<Key>();
                

                if (key != null)
                    key.AddCoin(coinValue);
                gameObject.SetActive(false);
            }
        }
    }


}
