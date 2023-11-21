using UnityEngine;
using UnityEngine.UI; // Include the UI namespace to use UI components

public class TableGazeFollower : MonoBehaviour
{
    [SerializeField] private GameObject table; // The table to rotate
    private bool isGazeFollowingEnabled = false;

    [SerializeField] private Button calibrationButton; // Reference to the UI button

    void Start()
    {
        // Ensure the button has the onClick listener attached
        calibrationButton.onClick.AddListener(ToggleGazeFollowMode);
    }

    public void ToggleGazeFollowMode()
    {
        isGazeFollowingEnabled = !isGazeFollowingEnabled; // Toggle the mode
        // Optional: provide feedback, like changing the button's text
        calibrationButton.GetComponentInChildren<Text>().text = isGazeFollowingEnabled ? "Lock Table Orientation" : "Calibrate Table Orientation";
    }

    void Update()
    {
        if (isGazeFollowingEnabled)
        {
            // Use the camera's forward direction as the gaze direction
            Vector3 gazeDirection = Camera.main.transform.forward;
            gazeDirection.y = 0; // Keep the table rotation horizontal
            Quaternion targetRotation = Quaternion.LookRotation(gazeDirection);
            table.transform.rotation = Quaternion.Slerp(table.transform.rotation, targetRotation, Time.deltaTime * 5);
        }
    }
}
