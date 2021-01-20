using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{

    public class VarServer : MonoBehaviour
    {
        public enum COperationType { None, Initialize, Runtime }

        [Space(10)]
        public bool isEnabled;

        [Header("Operation Settings")]
        public COperationType OperationType;

        [Header("Server Settings")]
        public VarString ConnectURL;
        public VarString LoginURL;
        public VarString RegisterURL;
        public VarString UpdateScoreURL;
        public VarString HighScoreURL;
        public VarString ForgotURL;

        [Header("Server Event Settings")]
        public UnityEvent ServerEvent;

        string ConfigDirectory = "Config";
        string ServerDirectory = "Server";

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        string GetDirectory(string aDirectoryName)
        {
            if (!Directory.Exists(Application.persistentDataPath + "/" + aDirectoryName + "/"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + aDirectoryName + "/");
            }
            return Application.persistentDataPath + "/" + aDirectoryName + "/";
        }

        public void SaveFile()
        {
            string header = "<ServerSettings>\n";
            string footer = "</ServerSettings>";
            string result = "";

            string opentag0 = "\t<" + "ConnectURL" + ">\n";
            string contenttag0 = "\t\t" + ConnectURL.CurrentValue + "\n";
            string closetag0 = "\t</" + "ConnectURL" + ">\n";

            string opentag1 = "\t<" + "LoginURL" + ">\n";
            string contenttag1 = "\t\t" + LoginURL.CurrentValue + "\n";
            string closetag1 = "\t</" + "LoginURL" + ">\n";

            string opentag2 = "\t<" + "RegisterURL" + ">\n";
            string contenttag2 = "\t\t" + RegisterURL.CurrentValue + "\n";
            string closetag2 = "\t</" + "RegisterURL" + ">\n";

            string opentag3 = "\t<" + "UpdateScoreURL" + ">\n";
            string contenttag3 = "\t\t" + UpdateScoreURL.CurrentValue + "\n";
            string closetag3 = "\t</" + "UpdateScoreURL" + ">\n";

            string opentag4 = "\t<" + "HighScoreURL" + ">\n";
            string contenttag4 = "\t\t" + HighScoreURL.CurrentValue + "\n";
            string closetag4 = "\t</" + "HighScoreURL" + ">\n";

            string opentag5 = "\t<" + "ForgotURL" + ">\n";
            string contenttag5 = "\t\t" + ForgotURL.CurrentValue + "\n";
            string closetag5 = "\t</" + "ForgotURL" + ">\n";

            result = opentag0 + contenttag0 + closetag0 +
                     opentag1 + contenttag1 + closetag1 +
                     opentag2 + contenttag2 + closetag2 +
                     opentag3 + contenttag3 + closetag3 +
                     opentag4 + contenttag4 + closetag4 +
                     opentag5 + contenttag5 + closetag5;
            result = header + result + footer;

            string DirName = GetDirectory(ConfigDirectory);
            var sr = File.CreateText(DirName + "Server.xml");
            sr.WriteLine(result);
            sr.Close();
        }

        public void LoadFile()
        {
            string FullPathFile = GetDirectory(ConfigDirectory) + "Server.xml";
            if (File.Exists(FullPathFile))
            {
                string tempxml = System.IO.File.ReadAllText(FullPathFile);

                XmlDocument xmldoc;
                XmlNodeList xmlnodelist;
                XmlNode xmlnode;
                xmldoc = new XmlDocument();
                xmldoc.LoadXml(tempxml);

                xmlnodelist = xmldoc.GetElementsByTagName("ConnectURL");
                ConnectURL.CurrentValue = xmlnodelist.Item(0).InnerText.Trim();

                xmlnodelist = xmldoc.GetElementsByTagName("LoginURL");
                LoginURL.CurrentValue = xmlnodelist.Item(0).InnerText.Trim();

                xmlnodelist = xmldoc.GetElementsByTagName("RegisterURL");
                RegisterURL.CurrentValue = xmlnodelist.Item(0).InnerText.Trim();

                xmlnodelist = xmldoc.GetElementsByTagName("UpdateScoreURL");
                UpdateScoreURL.CurrentValue = xmlnodelist.Item(0).InnerText.Trim();

                xmlnodelist = xmldoc.GetElementsByTagName("HighScoreURL");
                HighScoreURL.CurrentValue = xmlnodelist.Item(0).InnerText.Trim();

                ServerEvent.Invoke();
            }
        }

        void Awake()
        {
            if (isEnabled)
            {
                if (OperationType == COperationType.Initialize)
                {
                    SaveFile();
                    LoadFile();
                }
                if (OperationType == COperationType.Runtime)
                {
                    LoadFile();
                }
            }
        }
    }
}
