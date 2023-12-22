using UnityEngine;

public class TableCalibration : MonoBehaviour
{
    [SerializeField]
    private GameObject table; // The table that you want to recalibrate.

    [SerializeField]
    private GameObject adjustmentCube; // The adjustment cube that you want to reposition.

    [SerializeField]
    private GameObject tableAdjustmentSpawner; // The spawner's location where the cube will be moved to.

    [SerializeField]
    private MonoBehaviour cubeMovementScript; // The actual movement script attached to the adjustment cube.

    public void CalibrateTable()
    {
        // Optionally, deactivate the movement script on the adjustment cube.
        if (cubeMovementScript != null)
        {
            cubeMovementScript.enabled = false;
        }

        // Extract the camera's position and horizontal (yaw) rotation.
        Transform cameraTransform = Camera.main.transform;
        Quaternion horizontalRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        // Fixed offsets for consistent distance from the camera.
        Vector3 fixedOffset = new Vector3(0, -1.014f, 0.29f);

        // Calculate the new position for the table using the fixed offsets and horizontal rotation.
        Vector3 newTablePosition = cameraTransform.position + horizontalRotation * fixedOffset;

        // Set the table's new position and rotation.
        table.transform.position = newTablePosition;
        table.transform.rotation = Quaternion.identity; // Reset to world axis alignment.

        // Move the adjustment cube to the spawner's position.
        if (tableAdjustmentSpawner != null)
        {
            adjustmentCube.transform.position = tableAdjustmentSpawner.transform.position;
        }

        // Optionally, reactivate the movement script on the adjustment cube.
        if (cubeMovementScript != null)
        {
            cubeMovementScript.enabled = true;
        }

        Debug.Log("Table and adjustment cube have been re-calibrated to the new origin point.");
    }
}
