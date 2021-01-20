using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class GetModel : MonoBehaviour
    {
        public bool isEnabled;

        [Header("Login Settings")]
        public VarString MainURL;
        public string FunctionURL;
        [HideInInspector] public string SubmitURL;

        [Header("Variable Settings")]
        public VarString SessionName;
        public string LevelName;

        [Header("Output Settings")]
        public VarString RequestOutput;
        public bool PrintDebugConsole;

        [Header("Outvar Settings")]
        public bool usingVarBool;
        public VarBoolean OutVarBool;
        public UnityEvent VarBoolEventTrue;
        public UnityEvent VarBoolEventFalse;

        public bool usingVarInteger;
        public VarInteger OutVarInteger;
        public UnityEvent VarIntegerEvent;

        public bool usingVarFloat;
        public VarFloat OutVarFloat;
        public UnityEvent VarFloatEvent;

        public void InvokeGetConnectModel()
        {
            MainURL.CurrentValue = MainURL.CurrentValue.Replace("/connect", "");

            SubmitURL = MainURL.CurrentValue + "/" + FunctionURL +
                       "/" + SessionName.CurrentValue +
                       "/" + LevelName;
            StartCoroutine(StartPHPRequest());
        }

        public void InvokeGetModel()
        {
            SubmitURL = MainURL.CurrentValue + "/" + FunctionURL +
                       "/" + SessionName.CurrentValue +
                       "/" + LevelName;
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
                RequestOutput.CurrentValue = webRequest.downloadHandler.text;
                if (PrintDebugConsole)
                {
                    Debug.Log(SubmitURL);
                    Debug.Log(webRequest.downloadHandler.text);
                }

                if (usingVarBool)
                {
                    if (RequestOutput.CurrentValue == "1")
                    {
                        OutVarBool.CurrentValue = true;
                        VarBoolEventTrue.Invoke();
                    }
                    else
                    {
                        OutVarBool.CurrentValue = false;
                        VarBoolEventFalse.Invoke();
                    }
                }
                if (usingVarInteger)
                {
                    OutVarInteger.CurrentValue = ToInteger(RequestOutput.CurrentValue);
                    VarIntegerEvent.Invoke();
                }
                if (usingVarFloat)
                {
                    OutVarFloat.CurrentValue = ToFloat(RequestOutput.CurrentValue);
                    VarFloatEvent.Invoke();
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
