using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class RegisterModel : MonoBehaviour
    {
        public bool isEnabled;

        [Header("Login Settings")]
        public VarString MainURL;
        [HideInInspector] public string SubmitURL;

        [Header("Variable Settings")]
        public InputField ID;
        public InputField Email;
        public InputField Nickname;
        public InputField Password;
        public InputField PasswordAgain;

        [Header("Output Settings")]
        public VarString RequestOutput;
        public bool PrintDebugConsole;

        [Header("Login Result")]
        public UnityEvent PasswordConfirmationEvent;
        public UnityEvent UserExistsEvent;
        public UnityEvent SuccessEvent;
        public UnityEvent FailedEvent;

        public void InvokeRegister()
        {
            if (Password.text != PasswordAgain.text)
            {
                PasswordConfirmationEvent.Invoke();
            } else
            {
                SubmitURL = MainURL.CurrentValue + 
                           "/" + ID.text +
                           "/" + Email.text +
                           "/" + Nickname.text +
                           "/" + Password.text +
                           "/0" + //default score = 0
                           "/120" + //default energy = 120
                           "/0" + //default coin = 0
                           "/0" + //default diamond = 0
                            "/0"; //default star = 0
                StartCoroutine(StartPHPRequest());
            }
        }

        IEnumerator StartPHPRequest()
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(SubmitURL);
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                if (PrintDebugConsole)
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

            if (RequestOutput.CurrentValue == "CREATE_USER_FAILED")
            {
                FailedEvent.Invoke();
            } 
            else if (RequestOutput.CurrentValue == "CREATE_USER_SUCCESS")
            {
                SuccessEvent.Invoke();
            }
            else if (RequestOutput.CurrentValue == "USER_ALREADY_EXISTS")
            {
                UserExistsEvent.Invoke();
            }
            else
            {
                FailedEvent.Invoke();
            }
        }

        public void CreateUserFailed()
        {
            Debug.Log("Message::CreateUserFailed");
        }

        public void CreateUserSuccess()
        {
            Debug.Log("Message::CreateUserSuccess");
        }

        public void CreateUserExists()
        {
            Debug.Log("Message::UserAlreadyExists");
        }

        public void CreatePasswordFailed()
        {
            Debug.Log("Message::Password Not Same");
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
