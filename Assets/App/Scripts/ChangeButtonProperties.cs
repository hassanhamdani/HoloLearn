using UnityEngine;
using TMPro; 

public class ChangeButtonProperties : MonoBehaviour
{
    public GameObject backplate; 
    public TextMeshPro text;     

    private Color originalBackplateColor;
    private string originalText;

    private bool isSessionStarted = false;

    private void Start()
    {
        originalBackplateColor = backplate.GetComponent<Renderer>().material.color;
        originalText = text.text;
    }

    public void OnButtonClick()
    {
        if(isSessionStarted)
        {
            // Change backplate color to original color
            backplate.GetComponent<Renderer>().material.color = originalBackplateColor;

            // Change text to original text
            text.text = originalText;
        }
        else
        {
            // Change backplate color to red
            backplate.GetComponent<Renderer>().material.color = Color.red;

            // Change text to "End Session"
            text.text = "End Session";
        }

        // Toggle the state
        isSessionStarted = !isSessionStarted;
    }
}
