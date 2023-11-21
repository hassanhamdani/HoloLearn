using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMover : MonoBehaviour
{

    float yPosition;
    float xPosition;
    float zPosition;



    //Serialize field for the table
    [SerializeField] GameObject table;
   


    void Start()
    {
        //get the Y position of the current object
        yPosition = transform.position.y;
        xPosition = transform.position.x;
        zPosition = transform.position.z;

        
    }

    // Update is called once per frame
    void Update()
    {
        //check for a change in the Y position of the current object
        if (transform.position.y != yPosition)
        {
            //if there is a change, add the difference to the table's Y position
            table.transform.position += new Vector3(0, transform.position.y - yPosition, 0);
            //update the yPosition variable
            yPosition = transform.position.y;
        }

        //check for a change in the X position of the current object
        if (transform.position.x != xPosition)
        {
            //if there is a change, add the difference to the table's X position
            table.transform.position += new Vector3(transform.position.x - xPosition, 0, 0);
            //update the xPosition variable
            xPosition = transform.position.x;
        }

        //check for a change in the Z position of the current object
        if (transform.position.z != zPosition)
        {
            //if there is a change, add the difference to the table's Z position
            table.transform.position += new Vector3(0, 0, transform.position.z - zPosition);
            //update the zPosition variable
            zPosition = transform.position.z;
        }

      
    }

    
}
