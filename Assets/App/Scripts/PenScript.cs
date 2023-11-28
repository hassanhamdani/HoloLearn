using UnityEngine;

public class PenScript : MonoBehaviour
{
    [SerializeField] private GameObject pencilTip; // Assign the pencil tip GameObject in the inspector
    [SerializeField] private GameObject paper; // Assign the paper GameObject in the inspector
    [SerializeField] private Material lineMaterial; // Assign a suitable material for the line in the inspector

    private LineRenderer currentLineRenderer;
    private Vector3 lastPosition;
    private bool isDrawing = false;

    void Update()
    {
        // Perform a raycast from the pencil tip in the direction it's facing
        if (Physics.Raycast(pencilTip.transform.position, pencilTip.transform.forward, out RaycastHit hit))
        {
            // Check if the raycast hit the paper GameObject
            if (hit.collider.gameObject == paper)
            {
                if (!isDrawing)
                {
                    // Start a new line
                    StartDrawing(hit.point);
                }
                else
                {
                    // Continue drawing the line
                    ContinueDrawing(hit.point);
                }
            }
        }
        else if (isDrawing)
        {
            // If the pencil is no longer in contact with the paper, stop drawing
            FinishDrawing();
        }
    }

    private void StartDrawing(Vector3 startPosition)
    {
        isDrawing = true;
        lastPosition = startPosition;

        // Create a new GameObject to hold the LineRenderer
        GameObject lineObj = new GameObject("Line");
        currentLineRenderer = lineObj.AddComponent<LineRenderer>();

        // Set the lineObj GameObject as a child of the paper GameObject
        lineObj.transform.SetParent(paper.transform, false);


        // Set up the LineRenderer
        currentLineRenderer.material = lineMaterial;
        currentLineRenderer.startWidth = 0.005f; // Change this value to change the line thickness
        currentLineRenderer.endWidth = 0.005f;
        currentLineRenderer.positionCount = 2;
        currentLineRenderer.useWorldSpace = true;
        currentLineRenderer.SetPosition(0, startPosition);
        currentLineRenderer.SetPosition(1, startPosition);
    }

    private void ContinueDrawing(Vector3 currentPosition)
    {
        if (Vector3.Distance(lastPosition, currentPosition) > 0.005f) // Adjust this value to change how often points are added
        {
            // Add a new point to the line
            currentLineRenderer.positionCount++;
            currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, currentPosition);
            lastPosition = currentPosition;
        }
    }

    private void FinishDrawing()
    {
        isDrawing = false;
    }
}