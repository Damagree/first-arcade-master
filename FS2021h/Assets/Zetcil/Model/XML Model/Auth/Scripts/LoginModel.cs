using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class LoginModel : MonoBehaviour
    {
        public bool isEnabled;

        [Header("Login Settings")]
        public VarString MainURL;
        [HideInInspector] public string SubmitURL;

        [Header("Variable Settings")]
        public InputField ID;
        public InputField Password;

        [Header("Output Settings")]
        public VarString RequestOutput;
        public bool PrintDebugConsole;

        [Header("Login Result")]
        public UnityEvent SuccessEvent;
        public UnityEvent FailedEvent;

        [Header("User Output")]
        public bool usingUserOutput;
        public VarString UserID;
        public VarString UserEmail;
        public VarString UserNickname;
        public VarString UserPassword;
        public VarScore UserScore;
        public VarInteger UserEnergy;
        public VarInteger UserCoin;
        public VarInteger UserDiamond;
        public VarInteger UserStar;
        public UnityEvent SessionEvent;

        public void InvokeAdminLogin()
        {
            if (ID.text == "admin" && Password.text == "admin")
            {
                SuccessEvent.Invoke();
            } else
            {
                FailedEvent.Invoke();
            }
        }

        public void InvokeLogin()
        {
            SubmitURL = MainURL.CurrentValue + 
                       "/" + ID.text +
                       "/" + Password.text;
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
            }

            string[] resLogin = RequestOutput.CurrentValue.Split('|');

            if (resLogin[0] == "LOGIN_FAILED")
            {
                FailedEvent.Invoke();
            }
            else if (resLogin[0] == "LOGIN_SUCCESS")
            {
                SuccessEvent.Invoke();

                if (usingUserOutput)
                {
                    UserID.CurrentValue = resLogin[1];
                    UserEmail.CurrentValue = resLogin[2];
                    UserNickname.CurrentValue = resLogin[3];
                    UserPassword.CurrentValue = resLogin[4];
                    UserScore.CurrentValue = ToInteger(resLogin[5]);
                    UserEnergy.CurrentValue = ToInteger(resLogin[6]);
                    UserCoin.CurrentValue = ToInteger(resLogin[7]);
                    UserDiamond.CurrentValue = ToInteger(resLogin[8]);
                    UserStar.CurrentValue = ToInteger(resLogin[9]);

                    SessionEvent.Invoke();
                }
            }
        }

        float ToFloat(string aValue)
        {
            float result = 0;
            if (aValue == "")
            {
                result = 0;
            } else 
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

        public void LoginFailed()
        {
            Debug.Log("Message::LoginFailed");
        }

        public void LoginSuccess()
        {
            Debug.Log("Message::LoginSuccess");
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
