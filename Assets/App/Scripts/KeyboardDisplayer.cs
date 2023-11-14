using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class KeyboardDisplayer : MonoBehaviour
{

    public TouchScreenKeyboard keyboard;

    //serialize field for a TMPro
    [SerializeField] TextMeshPro textMesh;
    
    public void OpenSystemKeyboard()
    {
        Debug.Log("OpenSystemKeyboard");
    keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
}
    // Update is called once per frame
    void Update()
    {
      if (keyboard != null)
    {
        string keyboardText = keyboard.text;
        // get the text from the keyboard and update the text mesh
        textMesh.text += keyboardText;
        keyboard.text = "";
       

    }  
    }
}
