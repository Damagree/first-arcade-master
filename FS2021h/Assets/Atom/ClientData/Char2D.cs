using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCreator2D
{
    public class Char2D : MonoBehaviour
    {
        // Start is called before the first frame update
        public CharacterViewer TargetCharacter;
        public Color ShowColor;
        public Color HideColor;

        public void ShowCharacter()
        {
            TargetCharacter.TintColor = ShowColor;
            TargetCharacter.RepaintTintColor();
        }
        public void HideCharacter()
        {
            TargetCharacter.TintColor = HideColor;
            TargetCharacter.RepaintTintColor();
        }

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
