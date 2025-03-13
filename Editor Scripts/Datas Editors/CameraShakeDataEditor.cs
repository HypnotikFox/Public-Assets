using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraShakeData))]

public class CameraShakeDataEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Reference to the SettingsManager script
        CameraShakeData cameraShakeData = (CameraShakeData)target;

        // Add buttons for each method
        GUILayout.Space(10);

        #region DELIVER BUTTON
        if (EditorApplication.isPlaying)
        {
            if (GUILayout.Button("Preview Camera Shake"))
            {
                var cameraManager = CameraManager.Instance;
                cameraManager.ShakeCamera(cameraShakeData, cameraManager.transform);
                // Just shake from the camera manager, what could possibly go wrong?
                // Just kidding, it works fine
            }
        }
        else
        {
            EditorGUI.BeginDisabledGroup(true);
            GUILayout.Button("Preview Camera Shake (Play Mode Only)");
            EditorGUI.EndDisabledGroup();
        }
        #endregion
    }
}
