using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Key key;          
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject pressEPrompt;
    [SerializeField] private GameObject spotlight;
    private bool playerInRange;
    private bool doorOpened;

    private void Awake()
    {
        animator.SetBool("isOpen", false);
        if (pressEPrompt != null)
            pressEPrompt.SetActive(false);
        //hides press e promt
    }

    private void Update()
    {

        if (doorOpened && playerInRange)
        {
            if (pressEPrompt != null)
                pressEPrompt.SetActive(true);
            //show e interaction promt

            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterDoor();
                //calls enter door method
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            if (!doorOpened && key.currentBar >= 4)
            {
                OpenDoor();
                //if player has collected all 4 keys and is in range of door, open door animation
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            if (pressEPrompt != null)
                pressEPrompt.SetActive(false);
            
            //if door is open and player is in range show e promt
        }
    }

    private void OpenDoor()
    {
        if (playerInRange && key.currentBar >= 4)
        {
            animator.SetBool("isOpen", true);
            Debug.Log("Door opening");
            doorOpened = true;
            if (spotlight != null)
                spotlight.SetActive(true);
            //door opening 
        }
    }

    private void EnterDoor()
    {
        Debug.Log("Entered door");
        SceneManager.LoadScene(3);

    }
}
