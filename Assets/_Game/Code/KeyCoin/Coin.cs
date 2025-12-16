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
                //calls the key amount from the player
                

                if (key != null)
                    key.AddCoin(coinValue);

                SoundEffectManager.Play("Coin");
                gameObject.SetActive(false);
                //if the player has the key component then add the coin value to it and remove the coin object
            }
        }
    }


}
