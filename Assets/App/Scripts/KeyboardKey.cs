using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for Unity's event system
using Microsoft.MixedReality.Toolkit.UI; // Required for MRTK

public class KeyboardKey : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Color defaultColor = Color.black;
    public Color pressedColor = Color.blue;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = defaultColor; // Set the default color
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        image.color = pressedColor; // Change color to simulate glow
        RegisterKeyPress();
        // Optionally add haptic feedback here using MRTK's haptic system
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.color = defaultColor; // Revert to the default color
    }

    private void RegisterKeyPress()
    {
        // Logic to handle the keypress
        Debug.Log($"{gameObject.name} key pressed.");
        // Here you would typically call another method to update your text input field or handle the input
    }
}
