using UnityEngine;
using TMPro; // Namespace for TMP_InputField

public class InputFieldManager : MonoBehaviour
{
    public TMP_InputField currentInputField; // The input field that is currently active

    // Call this method when an input field is selected
    public void SelectInputField(TMP_InputField inputField)
    {
        currentInputField = inputField; // Set the current input field to the one selected
    }


}
