using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using TechnomediaLabs;
using System.Net;
using System.IO;

namespace Zetcil
{
    public class ConnectModel : MonoBehaviour
    {
        public enum CConnectType { GoogleSite, CustomSite }

        public bool isEnabled;

        [Header("Main Settings")]
        public CConnectType ConnectType;
        public VarString MainURL;
        public VarString ServerURL;

        [Header("Timed Out Settings")]
        public int MaxTimeOut;
        int TryConnection = 0;

        [Header("Output Setting")]
        [TextArea(5, 10)]
        public string HTMLResult;

        [Header("Event Setings")]
        public UnityEvent NoConnectionEvent;
        public UnityEvent RedirectingEvent;
        public UnityEvent ConnectedEvent;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("CheckConnection", 1, 1);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void RestartConnection()
        {
            TryConnection = 0;
        }

        public void CheckConnection()
        {
            if (TryConnection < MaxTimeOut)
            {
                HTMLResult = GetHtmlFromUri(MainURL.CurrentValue);
                if (ConnectType == CConnectType.GoogleSite)
                {
                    if (HTMLResult == "")
                    {
                        NoConnectionEvent.Invoke();
                    }
                    else if (HTMLResult.Contains("schema.org/WebPage"))
                    {
                        //success
                        TryConnection = MaxTimeOut;
                        ConnectedEvent.Invoke();
                    } else
                    {
                        //Redirecting since the beginning of googles html contains that 
                        //phrase and it was not found
                        RedirectingEvent.Invoke();
                    }
                }else
                {
                    if (HTMLResult == "")
                    {
                        ServerURL.CurrentValue = MainURL.CurrentValue;
                        NoConnectionEvent.Invoke();
                    }
                    else if (HTMLResult.Contains("CONNECTED"))
                    {
                        string[] temp = HTMLResult.Split(':');
                        ServerURL.CurrentValue = temp[1];
                        TryConnection = MaxTimeOut;
                        ConnectedEvent.Invoke();
                    }
                    else
                    {
                        ServerURL.CurrentValue = HTMLResult;
                        RedirectingEvent.Invoke();
                    }
                }
            }
            TryConnection++;
        }

        public string GetHtmlFromUri(string resource)
        {
            string html = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
            try
            {
                using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
                {
                    bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                    if (isSuccess)
                    {
                        using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                        {
                            //We are limiting the array to 80 so we don't have
                            //to parse the entire html document feel free to 
                            //adjust (probably stay under 300)
                            char[] cs = new char[80];
                            reader.Read(cs, 0, cs.Length);
                            foreach (char ch in cs)
                            {
                                html += ch;
                            }
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                return e.Message;
            }
            return html;
        }
    }
}

