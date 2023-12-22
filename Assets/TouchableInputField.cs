using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;


public class TouchableInputField : MonoBehaviour, IMixedRealityTouchHandler
{
    private TMP_InputField inputField;
    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();

    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        inputField.Select();
        inputField.ActivateInputField();
    }

    // Implement the other required methods of the interface with empty bodies
    public void OnTouchCompleted(HandTrackingInputEventData eventData) { }
    public void OnTouchUpdated(HandTrackingInputEventData eventData) { }
}
