using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SSPCameraFollow)), CanEditMultipleObjects]
    public class SSPCameraFollowEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           CameraController,
           specificVector,
           smoothSpeed,
           offsetX,
           offsetY
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            CameraController = serializedObject.FindProperty("CameraController");
            specificVector = serializedObject.FindProperty("specificVector");
            smoothSpeed = serializedObject.FindProperty("smoothSpeed");
            offsetX = serializedObject.FindProperty("offsetX");
            offsetY = serializedObject.FindProperty("offsetY");
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
                EditorGUILayout.PropertyField(specificVector, true);
                EditorGUILayout.PropertyField(smoothSpeed, true);
                EditorGUILayout.PropertyField(offsetX, true);
                EditorGUILayout.PropertyField(offsetY, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}