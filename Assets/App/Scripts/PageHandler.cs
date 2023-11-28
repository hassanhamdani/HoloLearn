using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageHandler : MonoBehaviour
{
    // Start is called before the first frame update

    //serialize the field to set the parent object
    [SerializeField]
    private GameObject parentObject;

    //check for the next child in the hierarchy, make it active, adn deactivate the current one
    //make it so that one can reach the end of the children hierarchy

    public void NextPage()
    {
        //check the children and find the first active child
        int currentChild = 0;
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            if (parentObject.transform.GetChild(i).gameObject.activeSelf)
            {
                currentChild = i;
                break;
            }
        }

        int nextChild = currentChild + 1;

        if (nextChild < parentObject.transform.childCount)
        {
            parentObject.transform.GetChild(nextChild).gameObject.SetActive(true);
            parentObject.transform.GetChild(currentChild).gameObject.SetActive(false);
        }
    }

    public void PreviousPage()
    {
        //check the children and find the first active child
        int currentChild = 0;
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            if (parentObject.transform.GetChild(i).gameObject.activeSelf)
            {
                currentChild = i;
                break;
            }
        }

        int previousChild = currentChild - 1;

        if (previousChild >= 0)
        {
            parentObject.transform.GetChild(previousChild).gameObject.SetActive(true);
            parentObject.transform.GetChild(currentChild).gameObject.SetActive(false);
        }
    }


   
}
