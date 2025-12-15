using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    //array gets multiple options
    private RectTransform rect;
    private int currentPosition;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        //move up
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);
        //move down

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        Interact();
        //select current


    }
    private void ChangePosition(int _change)
    {
        currentPosition += _change;


        if (currentPosition < 0)
        { currentPosition = options.Length - 1; }


        else if (currentPosition > options.Length - 1)
        { currentPosition = 0; }

        //wraps around if the amount in array is exceeded


        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
        //moves arrow to be inline with the option selected
    }

    private void Interact()
    {

        options[currentPosition].GetComponent<Button>().onClick.Invoke();
        //clicks current option
    }

}
