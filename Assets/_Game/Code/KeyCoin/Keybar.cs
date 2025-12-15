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
        //sets the bar to be blank
    }


    private void Update()
    {
       
        currentkeyBar.fillAmount = playerCoins.currentBar / 4f;
        //updates the bar by 1 when player picks up a coin
        
    }

}
