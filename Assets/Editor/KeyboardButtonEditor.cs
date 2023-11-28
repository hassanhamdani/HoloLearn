using UnityEngine;
using UnityEditor;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class KeyboardButtonEditor : EditorWindow
{
    private GameObject keyboardAlpha;

    [MenuItem("Tools/Setup Keyboard Buttons")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        KeyboardButtonEditor window = (KeyboardButtonEditor)EditorWindow.GetWindow(typeof(KeyboardButtonEditor));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Setup Keyboard Buttons", EditorStyles.boldLabel);
        keyboardAlpha = (GameObject)EditorGUILayout.ObjectField("Keyboard Alpha Object", keyboardAlpha, typeof(GameObject), true);

        if (GUILayout.Button("Setup Buttons"))
        {
            if (keyboardAlpha != null)
            {
                SetupKeyboardButtons(keyboardAlpha);
            }
            else
            {
                Debug.LogError("Keyboard Alpha GameObject is not assigned.");
            }
        }
    }

    private static void SetupKeyboardButtons(GameObject keyboardAlpha)
    {
        foreach (Transform keyTransform in keyboardAlpha.transform)
        {
            // Add or get the existing PressableButtonHoloLens2 component
            var pressableButton = Undo.AddComponent<PressableButtonHoloLens2>(keyTransform.gameObject);

            // Set properties for PressableButtonHoloLens2
            pressableButton.MaxPushDistance = 0.015f;
           // pressableButton.MovingButtonVisuals = keyTransform.gameObject;

            // Add or get the existing NearInteractionTouchableUnityUI component
            var touchableUI = Undo.AddComponent<NearInteractionTouchableUnityUI>(keyTransform.gameObject);

            // Apply any additional settings here
        }

        Debug.Log("All buttons have been set up for " + keyboardAlpha.name);
    }
}
