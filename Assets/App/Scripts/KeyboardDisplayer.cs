using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class KeyboardDisplayer : MonoBehaviour
{

    public TouchScreenKeyboard keyboard;

    //serialize field for a TMPro
    [SerializeField] TextMeshPro textMesh;
    private bool isKeyboardVisible = false;

    public void ToggleKeyboard()
    {
        if (isKeyboardVisible)
        {
            // Hide the keyboard
            keyboard.active = false;
            keyboard = null;
            isKeyboardVisible = false;
        }
        else
        {
            // Show the keyboard
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true, false);
            isKeyboardVisible = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
      // Update the TextMeshPro text with the keyboard input
        if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Visible)
        {
            textMesh.text = keyboard.text;
        }
    }
}
