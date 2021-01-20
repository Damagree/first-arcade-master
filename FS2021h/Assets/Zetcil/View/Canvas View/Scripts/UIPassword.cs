using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zetcil
{
    public class UIPassword : MonoBehaviour
    {
        public bool isEnabled;

        public InputField TargetInputField;

        public void SetToStandard()
        {
            TargetInputField.contentType = InputField.ContentType.Alphanumeric;
            TargetInputField.Select();
        }

        public void SetToPassword()
        {
            TargetInputField.contentType = InputField.ContentType.Password;
            TargetInputField.Select();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
