/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 // * Desc   : Script untuk mengatur Spawn objek
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{

    public class SpawnController : MonoBehaviour
    {
        public enum CEnumAfterSpawn { StillWithParent, DetachFromParent }
        public enum CPrefabList { Static, Increment, Decrement, Random  }

        [Space(10)]
        public bool isEnabled;
        
        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("Prefab Settings")]
        public CPrefabList PrefabList;
        public List<GameObject> TargetPrefab;
        public int CurrentIndex;

        [Header("Spawn Settings")]
        [ReadOnly] public int TotalSpawn;
        public int MaxSpawn;

        [Header("Position Settings")]
        public Transform TargetPosition;

        [Header("Parent Settings")]
        public bool usingParent;
        public Transform TargetParent;
        public CEnumAfterSpawn AfterSpawn;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        public bool usingScale;
        public Vector3 SpawnScale;

        // Use this for initialization
        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                InvokeSpawnController();
            }
        }

        public void SetEnabled(bool aValue) { 
            isEnabled = aValue;
        }
        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeSpawnController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeSpawnController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeSpawnController", 1, Interval);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ExecuteSpawnController()
        {
            InvokeSpawnController();
        }

        public void InvokeSpawnController()
        {
            if (isEnabled && TotalSpawn < MaxSpawn)
            {
                if (usingParent)
                {
                    if (PrefabList == CPrefabList.Static)
                    {
                        GameObject static_temp = Instantiate(TargetPrefab[CurrentIndex], TargetPosition.position, TargetPosition.rotation, TargetParent);

                        if (usingScale)
                        {
                            static_temp.transform.localScale = SpawnScale;
                        }

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                    }

                    if (PrefabList == CPrefabList.Increment)
                    {
                        GameObject static_temp = Instantiate(TargetPrefab[CurrentIndex], TargetPosition.position, TargetPosition.rotation, TargetParent);

                        if (usingScale)
                        {
                            static_temp.transform.localScale = SpawnScale;
                        }


                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                        CurrentIndex++;
                        if (CurrentIndex >= TargetPrefab.Count)
                        {
                            CurrentIndex = 0;
                        }

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                    }

                    if (PrefabList == CPrefabList.Decrement)
                    {
                        CurrentIndex--;
                        if (CurrentIndex <= 0)
                        {
                            CurrentIndex = TargetPrefab.Count - 1;
                        }

                        GameObject static_temp = Instantiate(TargetPrefab[CurrentIndex], TargetPosition.position, TargetPosition.rotation, TargetParent);

                        if (usingScale)
                        {
                            static_temp.transform.localScale = SpawnScale;
                        }

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                    }

                    if (PrefabList == CPrefabList.Random)
                    {
                        CurrentIndex = Random.Range(0, TargetPrefab.Count - 1);

                        GameObject static_temp = Instantiate(TargetPrefab[CurrentIndex], TargetPosition.position, TargetPosition.rotation, TargetParent);

                        if (usingScale)
                        {
                            static_temp.transform.localScale = SpawnScale;
                        }

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                    }
                }
                else
                {
                    if (PrefabList == CPrefabList.Static)
                    {
                        GameObject static_temp = Instantiate(TargetPrefab[CurrentIndex], TargetPosition.position, TargetPosition.rotation);

                        if (usingScale)
                        {
                            static_temp.transform.localScale = SpawnScale;
                        }

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                    }

                    if (PrefabList == CPrefabList.Increment)
                    {
                        GameObject static_temp = Instantiate(TargetPrefab[CurrentIndex], TargetPosition.position, TargetPosition.rotation);

                        if (usingScale)
                        {
                            static_temp.transform.localScale = SpawnScale;
                        }

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                        CurrentIndex++;
                        if (CurrentIndex >= TargetPrefab.Count)
                        {
                            CurrentIndex = 0;
                        }

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                    }

                    if (PrefabList == CPrefabList.Decrement)
                    {
                        CurrentIndex--;
                        if (CurrentIndex <= 0)
                        {
                            CurrentIndex = TargetPrefab.Count - 1;
                        }

                        GameObject static_temp = Instantiate(TargetPrefab[CurrentIndex], TargetPosition.position, TargetPosition.rotation);

                        if (usingScale)
                        {
                            static_temp.transform.localScale = SpawnScale;
                        }

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                    }

                    if (PrefabList == CPrefabList.Random)
                    {
                        CurrentIndex = Random.Range(0, TargetPrefab.Count - 1);

                        GameObject static_temp = Instantiate(TargetPrefab[CurrentIndex], TargetPosition.position, TargetPosition.rotation);

                        if (usingScale)
                        {
                            static_temp.transform.localScale = SpawnScale;
                        }

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");

                        if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                        {
                            static_temp.transform.parent = null;
                        }
                        if (static_temp == null) Debug.Log("Spawn Failed.");
                    }
                }

                TotalSpawn++;
            }
        }

    }
}
