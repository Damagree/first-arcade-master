using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TechnomediaLabs;

namespace Zetcil
{
    public class VarScene : MonoBehaviour
    {

        public VarString LevelName;

        // Start is called before the first frame update
        void Start()
        {
            LevelName.CurrentValue = SceneManager.GetActiveScene().name;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
