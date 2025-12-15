using UnityEngine;
using UnityEngine.UI;

public class totalBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 3;
        //sets the healthbar to full at the start
    }


    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 3;
        //updates the healthbar to match the hp the player currently has 
    }

}
