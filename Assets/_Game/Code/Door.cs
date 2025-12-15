using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] private Key key;          
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject pressEPrompt;
    private bool playerInRange;
    private bool doorOpened;

    private void Awake()
    {
        animator.SetBool("isOpen", false);
        if (pressEPrompt != null)
            pressEPrompt.SetActive(false);
    }

    private void Update()
    {

        if (doorOpened && playerInRange)
        {
            if (pressEPrompt != null)
                pressEPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterDoor();
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
        }
    }

    private void OpenDoor()
    {
        if (playerInRange && key.currentBar >= 4)
        {
            animator.SetBool("isOpen", true);
            Debug.Log("Door opening");
            doorOpened = true;
        }
    }

    private void EnterDoor()
    {
        Debug.Log("Entered door");

        // TODO: Replace with what entering does:
        // SceneManager.LoadScene("NextLevel");
        // OR teleport player
    }
}
