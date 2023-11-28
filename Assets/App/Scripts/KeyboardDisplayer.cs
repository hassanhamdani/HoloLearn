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
       
    }


    // Update is called once per frame
    void Update()
    {
      
    }
}
