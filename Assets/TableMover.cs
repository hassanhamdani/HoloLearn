using UnityEngine;

public class TableMover : MonoBehaviour
{
    public GameObject table; // Assign the table GameObject in the inspector
    private Vector3 initialOffset;
    private Vector3 previousCubePosition;

    void Start()
    {
        // Save the initial offset between the cube and the table
        initialOffset = table.transform.position - transform.position;
        previousCubePosition = transform.position; // Save the initial position of the cube
    }

    void Update()
    {
        // Calculate the current offset from the cube to the table
        Vector3 currentOffset = table.transform.position - transform.position;

        // If the cube has moved
        if (transform.position != previousCubePosition)
        {
            // Move the table to maintain the initial offset relative to the cube
            table.transform.position = transform.position + initialOffset;

            // Update previousCubePosition for the next frame
            previousCubePosition = transform.position;
        }
    }
}
