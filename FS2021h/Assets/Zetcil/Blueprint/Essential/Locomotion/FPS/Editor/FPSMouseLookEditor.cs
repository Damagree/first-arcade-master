using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(FPSMouseLook)), CanEditMultipleObjects]
    public class FPSMouseLookEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           lookAutomatic,
           lookSensitivity,
           lookSmoothnes,
           CameraController
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            lookAutomatic = serializedObject.FindProperty("lookAutomatic");
            lookSensitivity = serializedObject.FindProperty("lookSensitivity");
            lookSmoothnes = serializedObject.FindProperty("lookSmoothnes");
            CameraController = serializedObject.FindProperty("CameraController");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(CameraController, true);
                if (CameraController.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(lookAutomatic, true);
                EditorGUILayout.PropertyField(lookSensitivity, true);
                EditorGUILayout.PropertyField(lookSmoothnes, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}