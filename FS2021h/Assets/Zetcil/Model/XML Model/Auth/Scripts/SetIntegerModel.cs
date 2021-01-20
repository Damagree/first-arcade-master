using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class SetIntegerModel : MonoBehaviour
    {
        public bool isEnabled;

        [Header("Login Settings")]
        public VarString MainURL;
        public string FunctionURL;
        [HideInInspector] public string SubmitURL;

        [Header("Level Settings")]
        public VarString LevelName;

        [Header("Variable Settings")]
        public VarString SessionName;
        public VarInteger Value;

        [Header("Output Settings")]
        [TextArea(5, 10)]
        public string RequestOutput;
        public bool PrintDebugConsole;

        public void InvokeSetConnectModel()
        {
            MainURL.CurrentValue = MainURL.CurrentValue.Replace("/connect", "");

            SubmitURL = MainURL.CurrentValue + "/" + FunctionURL +
                       "/" + SessionName.CurrentValue +
                       "/" + LevelName.CurrentValue +
                       "/" + Value.CurrentValue.ToString();
            StartCoroutine(StartPHPRequest());
        }

        public void InvokeSetModel()
        {
            SubmitURL = MainURL.CurrentValue + "/" + FunctionURL +
                       "/" + SessionName.CurrentValue +
                       "/" + LevelName.CurrentValue +
                       "/" + Value.CurrentValue.ToString();
            StartCoroutine(StartPHPRequest());
        }

        IEnumerator StartPHPRequest()
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(SubmitURL);
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                {
                    Debug.Log(SubmitURL);
                    Debug.Log(webRequest.downloadHandler.text);
                }
            }
            else
            {
                RequestOutput = webRequest.downloadHandler.text;
                if (PrintDebugConsole)
                {
                    Debug.Log(SubmitURL);
                    Debug.Log(webRequest.downloadHandler.text);
                }
            }
        }

        float ToFloat(string aValue)
        {
            float result = 0;
            if (aValue == "")
            {
                result = 0;
            }
            else
            {
                result = float.Parse(aValue);
            }
            return result;
        }

        int ToInteger(string aValue)
        {
            int result = 0;
            if (aValue == "")
            {
                result = 0;
            }
            else
            {
                result = int.Parse(aValue);
            }
            return result;
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
