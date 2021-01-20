using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(FPSController)), CanEditMultipleObjects]
    public class FPSControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           walkSpeed,
           jumpSpeed,
           runSpeed
        ;

        void OnEnable()
        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            walkSpeed = serializedObject.FindProperty("walkSpeed");
            jumpSpeed = serializedObject.FindProperty("jumpSpeed");
            runSpeed = serializedObject.FindProperty("runSpeed");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(walkSpeed, true);
                EditorGUILayout.PropertyField(jumpSpeed, true);
                EditorGUILayout.PropertyField(runSpeed, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}