using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{
    public class VarNavigation : MonoBehaviour
    {
        [System.Serializable]
        public class CVarNav {
            public string Name;
            public GameObject Object;
        }

        [System.Serializable]
        public class CVarDesc
        {
            public string Name;
            [TextArea(10, 25)]
            public string Description;
        }

        [Header("Scene Navigation")]
        public List<CVarDesc> Information;

        [Header("Server Settings")]
        public List<CVarNav> Server;

        [Header("Session Settings")]
        public List<CVarNav> Session;

        [Header("Level Settings")]
        public List<CVarNav> Level;

        [Header("Score Settings")]
        public List<CVarNav> Score;

        [Header("Star Settings")]
        public List<CVarNav> Star;

        [Header("Pause Settings")]
        public List<CVarNav> Pause;

        [Header("Time Settings")]
        public List<CVarNav> Time;

        [Header("Win Settings")]
        public List<CVarNav> Win;

        [Header("Lose Settings")]
        public List<CVarNav> Lose;

        [Header("Times Up Settings")]
        public List<CVarNav> TimesUp;

        [Header("Player Settings")]
        public List<CVarNav> Player;

        [Header("Game Settings")]
        public List<CVarNav> Game;

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
