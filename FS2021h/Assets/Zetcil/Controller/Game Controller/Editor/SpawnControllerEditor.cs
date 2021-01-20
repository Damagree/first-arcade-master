using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SpawnController)), CanEditMultipleObjects]
    public class SpawnControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            InvokeType,
            PrefabList,
            TargetPrefab,
            CurrentIndex,
            TargetPosition,
            usingParent,
            TargetParent,
            AfterSpawn,
            TotalSpawn,
            MaxSpawn,
            usingDelay,
            Delay,
            usingInterval,
            Interval,
            usingScale,
            SpawnScale
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            InvokeType = serializedObject.FindProperty("InvokeType");
            PrefabList = serializedObject.FindProperty("PrefabList");
            TargetPrefab = serializedObject.FindProperty("TargetPrefab");
            CurrentIndex = serializedObject.FindProperty("CurrentIndex");
            TargetPosition = serializedObject.FindProperty("TargetPosition");
            usingParent = serializedObject.FindProperty("usingParent");
            TargetParent = serializedObject.FindProperty("TargetParent");
            usingDelay = serializedObject.FindProperty("usingDelay");
            AfterSpawn = serializedObject.FindProperty("AfterSpawn");
            TotalSpawn = serializedObject.FindProperty("TotalSpawn");
            MaxSpawn = serializedObject.FindProperty("MaxSpawn");
            Delay = serializedObject.FindProperty("Delay");
            usingInterval = serializedObject.FindProperty("usingInterval");
            Interval = serializedObject.FindProperty("Interval");
            usingScale = serializedObject.FindProperty("usingScale");
            SpawnScale = serializedObject.FindProperty("SpawnScale");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {

                EditorGUILayout.PropertyField(InvokeType);

                EditorGUILayout.PropertyField(PrefabList);
                EditorGUILayout.PropertyField(TargetPrefab);
                if (TargetPrefab.arraySize == 0)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(CurrentIndex);
                EditorGUILayout.PropertyField(TotalSpawn);
                EditorGUILayout.PropertyField(MaxSpawn);

                EditorGUILayout.PropertyField(TargetPosition);
                if (TargetPosition.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(usingParent);
                if (usingParent.boolValue)
                {
                    EditorGUILayout.PropertyField(AfterSpawn);
                    EditorGUILayout.PropertyField(TargetParent);
                    if (TargetParent.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
                }

                //--Invoke type (3)
                if ((GlobalVariable.CInvokeType)InvokeType.enumValueIndex == GlobalVariable.CInvokeType.OnDelay)
                { 
                    EditorGUILayout.PropertyField(usingDelay, true);
                    if (usingDelay.boolValue)
                    {
                        EditorGUILayout.PropertyField(Delay, true);
                    }
                }
                if ((GlobalVariable.CInvokeType)InvokeType.enumValueIndex == GlobalVariable.CInvokeType.OnInterval)
                {
                    EditorGUILayout.PropertyField(usingInterval, true);
                    if (usingInterval.boolValue)
                    {
                        EditorGUILayout.PropertyField(Interval, true);
                    }
                }

                EditorGUILayout.PropertyField(usingScale);
                EditorGUILayout.PropertyField(SpawnScale);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}