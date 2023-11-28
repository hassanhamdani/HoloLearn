using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ViewToggle : MonoBehaviour
{
    //Serial ize field for gameobject
    [SerializeField] GameObject viewObject;

    //New field for a text mesh 
    [SerializeField] TextMesh textMesh;

    //on button click, disable or enable the gameobject
    public void OnButtonClick()
    {
        //Toggle text between Off and On
        if (textMesh.text == "Off")
        {
            textMesh.text = "On";
        }
        else
        {
            textMesh.text = "Off";
        }

        viewObject.SetActive(!viewObject.activeSelf);
    }
}
