using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{
    public class UIInput : MonoBehaviour
    {

        public InputField TargetInputField;

        public void SetText(VarString aText)
        {
            TargetInputField.text = aText.CurrentValue;
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
