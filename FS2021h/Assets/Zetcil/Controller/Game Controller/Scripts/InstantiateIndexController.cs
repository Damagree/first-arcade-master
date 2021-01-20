/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 // * Desc   : Script untuk mengatur instantiate objek
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{

    public class InstantiateIndexController : MonoBehaviour
    {
        public enum CEnumAfterInstantiate { StillWithParent, DetachFromParent }

        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("Prefab Settings")]
        public GameObject TargetPrefab;

        [Header("Position Settings")]
        public VarInteger TargetIndex;
        public List<Transform> TargetPosition;
        public bool HideTargetAfter;

        [Header("Parent Settings")]
        public bool usingParent;
        public Transform TargetParent;
        public CEnumAfterInstantiate AfterInstantiate;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        [Header("After Instantiate")]
        public bool usingInstantiate;
        public UnityEvent InstantiateEvent;

        public void SetEnabled(bool aValue)
        {
            isEnabled = aValue;
        }

        // Use this for initialization
        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                InvokeInstantiateController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeInstantiateController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeInstantiateController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeInstantiateController", 1, Interval);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ExecuteInstantiateObjectWithDelay()
        {
            if (usingDelay)
            {
                Invoke("InvokeInstantiateController", Delay);
            }
        }

        public void ExecuteInstantiateEvent()
        {
            if (usingInstantiate)
            {
                InstantiateEvent.Invoke();
            }

        }

        public void InvokeInstantiateController()
        {
            if (usingParent)
            {
                if (isEnabled)
                {
                    GameObject temp = Instantiate(TargetPrefab, TargetPosition[TargetIndex.CurrentValue].position, TargetPosition[TargetIndex.CurrentValue].rotation, TargetParent);
                    if (AfterInstantiate == CEnumAfterInstantiate.DetachFromParent)
                    {
                        temp.transform.parent = null;
                    }
                    if (temp == null) Debug.Log("Instantiate Failed.");
                }
            }
            else
            {
                if (isEnabled)
                {
                    GameObject temp = Instantiate(TargetPrefab, TargetPosition[TargetIndex.CurrentValue].position, TargetPosition[TargetIndex.CurrentValue].rotation);
                    if (temp == null) Debug.Log("Instantiate Failed.");
                }
            }

            if (HideTargetAfter)
            {
                TargetPosition[TargetIndex.CurrentValue].parent.gameObject.SetActive(false);
            }

            Invoke("ExecuteInstantiateEvent",1);
        }

        public void ExecuteInstantiateObject()
        {
            if (usingParent)
            {
                if (isEnabled)
                {
                    GameObject temp = Instantiate(TargetPrefab, TargetPosition[TargetIndex.CurrentValue].position, TargetPosition[TargetIndex.CurrentValue].rotation, TargetParent);
                    if (AfterInstantiate == CEnumAfterInstantiate.DetachFromParent)
                    {
                        temp.transform.parent = null;
                    }
                    if (temp == null) Debug.Log("Instantiate Failed.");
                }
            }
            else
            {
                if (isEnabled)
                {
                    GameObject temp = Instantiate(TargetPrefab, TargetPosition[TargetIndex.CurrentValue].position, TargetPosition[TargetIndex.CurrentValue].rotation);
                    if (temp == null) Debug.Log("Instantiate Failed.");
                }
            }

            if (HideTargetAfter)
            {
                TargetPosition[TargetIndex.CurrentValue].parent.gameObject.SetActive(false);
            }

            Invoke("ExecuteInstantiateEvent", 1);
        }

        public void InstantiateAnotherObjectWithDelay()
        {
            if (usingDelay)
            {
                Invoke("InvokeInstantiateController", Delay);
            }
        }

        public void InstantiateAnotherObject()
        {
            if (usingParent)
            {
                if (isEnabled)
                {
                    GameObject temp = Instantiate(TargetPrefab, TargetPosition[TargetIndex.CurrentValue].position, TargetPosition[TargetIndex.CurrentValue].rotation, TargetParent);
                    if (AfterInstantiate == CEnumAfterInstantiate.DetachFromParent)
                    {
                        temp.transform.parent = null;
                    }
                    if (temp == null) Debug.Log("Instantiate Failed.");
                }
            }
            else
            {
                if (isEnabled)
                {
                    GameObject temp = Instantiate(TargetPrefab, TargetPosition[TargetIndex.CurrentValue].position, TargetPosition[TargetIndex.CurrentValue].rotation);
                    if (temp == null) Debug.Log("Instantiate Failed.");
                }
            }

            if (HideTargetAfter)
            {
                TargetPosition[TargetIndex.CurrentValue].parent.gameObject.SetActive(false);
            }

            Invoke("ExecuteInstantiateEvent", 1);
        }
    }
}
