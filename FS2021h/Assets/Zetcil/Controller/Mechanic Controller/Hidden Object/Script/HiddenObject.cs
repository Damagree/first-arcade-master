using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class HiddenObject : MonoBehaviour
    {
        public enum CFound { Active, Inactive }

        [Space(10)]
        public bool isEnabled;

        [Header("Hidden Object Controller")]
        public HiddenObjectController HiddenObjectManager;

        [Header("Found Settings")]
        public CFound FoundStatus;
        public string ObjectName;
        public Button ObjectButton;

        [Header("Event Settings")]
        public UnityEvent ActiveEvent;
        public UnityEvent InactiveEvent;
        public bool isFound = false;

        public void SetEnabled(bool aValue)
        {
            isEnabled = aValue;
        }

        public void SetActive(bool aValue)
        {
            if (aValue) FoundStatus = CFound.Active;
            else FoundStatus = CFound.Inactive;
        }

        public void InvokeEffect(GameObject SFXParticle)
        {
            GameObject temp = Instantiate(SFXParticle, this.gameObject.transform);
        }

        public void InvokeHide(float aSecond)
        {
            ObjectButton.gameObject.GetComponent<Button>().interactable = false;
            Invoke("SetHide", 1);
        }

        public void SetHide()
        {
            this.gameObject.SetActive(false);
            ObjectButton.gameObject.SetActive(false);
        }

        public void InvokeHiddenObject()
        {
            if (FoundStatus == CFound.Active)
            {
                HiddenObjectManager.InvokeFoundObject();
                ActiveEvent.Invoke();
            } else
            {
                InactiveEvent.Invoke();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if (FoundStatus == CFound.Active)
            {
                ObjectButton.GetComponentInChildren<Text>().text = ObjectName;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isFound)
            {
                this.gameObject.transform.Translate(Vector3.up * Time.deltaTime);
            }
        }
    }
}
