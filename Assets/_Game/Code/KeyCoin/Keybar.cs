using UnityEngine;
using UnityEngine.UI;

public class Keybar : MonoBehaviour
{
    [SerializeField] private Key playerCoins;
    [SerializeField] private Image totalkeyBar;
    [SerializeField] private Image currentkeyBar;


    private void Start()
    {
        totalkeyBar.fillAmount = 1f;
    }


    private void Update()
    {
       
        currentkeyBar.fillAmount = playerCoins.currentBar / 4f;
        
    }

}
