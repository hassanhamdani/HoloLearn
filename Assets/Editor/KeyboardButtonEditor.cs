using UnityEngine;
using UnityEditor;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class KeyboardButtonSetupEditor : EditorWindow
{
    private GameObject sourceButton;
    private GameObject keyboardAlpha;

    [MenuItem("Tools/Apply Button Settings")]
    private static void ShowWindow()
    {
        var window = GetWindow<KeyboardButtonSetupEditor>();
        window.titleContent = new GUIContent("Button Setup");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Copy Button Settings", EditorStyles.boldLabel);

        sourceButton = (GameObject)EditorGUILayout.ObjectField("Source Button", sourceButton, typeof(GameObject), true);
        keyboardAlpha = (GameObject)EditorGUILayout.ObjectField("Keyboard Alpha", keyboardAlpha, typeof(GameObject), true);

        if (GUILayout.Button("Apply Settings to All Buttons"))
        {
            ApplySettings();
        }
    }

    private void ApplySettings()
    {
        if (sourceButton == null || keyboardAlpha == null)
        {
            Debug.LogError("Please assign both the source button and the keyboard alpha.");
            return;
        }

        // Retrieve components from the source button
        PressableButtonHoloLens2 sourcePressableButton = sourceButton.GetComponent<PressableButtonHoloLens2>();
        AudioSource sourceAudioSource = sourceButton.GetComponent<AudioSource>();
        NearInteractionTouchableUnityUI sourceTouchable = sourceButton.GetComponent<NearInteractionTouchableUnityUI>();

        if (sourcePressableButton == null || sourceAudioSource == null || sourceTouchable == null)
        {
            Debug.LogError("The source button does not have all the required components.");
            return;
        }

        // Apply settings to all children buttons
        foreach (Transform child in keyboardAlpha.transform)
        {
            // Add or get the existing PressableButtonHoloLens2 component
            var childPressableButton = Undo.AddComponent<PressableButtonHoloLens2>(child.gameObject);
            EditorUtility.CopySerializedIfDifferent(sourcePressableButton, childPressableButton);
            
            //childPressableButton.MovingButtonVisuals = child.GetComponent<Transform>();  //Set to self

            // Add a new AudioSource component and copy the settings
            var childAudioSource = Undo.AddComponent<AudioSource>(child.gameObject);
            EditorUtility.CopySerialized(sourceAudioSource, childAudioSource);

            // Add or get the existing NearInteractionTouchableUnityUI component
            var childTouchable = Undo.AddComponent<NearInteractionTouchableUnityUI>(child.gameObject);
            EditorUtility.CopySerializedIfDifferent(sourceTouchable, childTouchable);
        }

        Debug.Log("Settings have been applied to all buttons.");
    }
}
