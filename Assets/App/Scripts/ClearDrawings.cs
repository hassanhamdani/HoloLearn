using UnityEngine;
public class ClearDrawings : MonoBehaviour
{
    public GameObject paperGameObject; // Assign this in the inspector to your Paper GameObject

    // Call this method when the button is pressed
    public void OnButtonClick()
    {
        Debug.Log("EraseAllDrawings() called");

        // Check if paperGameObject is not null
        if (paperGameObject == null)
        {
            Debug.LogError("Paper GameObject is not assigned.");
            return;
        }

        // Iterate over all children of the paperGameObject
        for (int i = paperGameObject.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = paperGameObject.transform.GetChild(i);
            // Check if the child's name is "Line"
            if (child.name == "Line")
            {
                // Destroy the child GameObject
                Destroy(child.gameObject);
            }
        }
    }
}

