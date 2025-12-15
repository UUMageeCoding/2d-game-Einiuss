using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float startingBar;
    [SerializeField] private float maxBar = 4f;
    public float currentBar { get; private set; }



    private void Awake()

    {
        currentBar = 0;
        //coin count
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
            Debug.Log("E");*/
    }


    public void AddCoin(float _value)
    {
        currentBar = Mathf.Clamp(currentBar + _value, 0, maxBar);
        //add 1 to coinbar everytime player collects coin


        //Debug.Log( currentBar);

    }
}
