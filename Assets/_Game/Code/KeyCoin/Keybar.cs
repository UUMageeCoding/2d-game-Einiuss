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
        Debug.Log("UI sees bar: " + playerCoins.currentBar);
        currentkeyBar.fillAmount = playerCoins.currentBar / 4f;
        Debug.Log($"UI fill: {currentkeyBar.fillAmount}  bar: {playerCoins.currentBar}");
    }

}
