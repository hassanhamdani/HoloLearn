using UnityEngine;
using UnityEngine.UI; // Include the UI namespace to use UI components

public class TableGazeFollower : MonoBehaviour
{
    
    [SerializeField] public GameObject table; // Assign your table GameObject here in the inspector
    public Vector3 tableRelativePosition; // Set the desired position of the table relative to the user
    public Vector3 tableRelativeRotation; // Set the desired rotation of the table relative to the user

    // This method would be called when the calibration button is pressed
    public void CalibrateTable()
    {
        // Assuming you want to place the table a certain distance in front of the user
        Transform cameraTransform = Camera.main.transform;
        
        // Set the position in front of the camera, maintaining the table's original height
        table.transform.position = cameraTransform.position + cameraTransform.forward * tableRelativePosition.z;
        table.transform.position = new Vector3(table.transform.position.x, tableRelativePosition.y, table.transform.position.z);

        // Set the rotation to match the camera's rotation with an optional offset
        Quaternion rotationOffset = Quaternion.Euler(tableRelativeRotation);
        table.transform.rotation = cameraTransform.rotation * rotationOffset;
        
        Debug.Log("Table has been re-calibrated.");
    }
}



