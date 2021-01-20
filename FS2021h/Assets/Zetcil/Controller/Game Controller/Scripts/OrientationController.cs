using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class OrientationController : MonoBehaviour
    {
        public enum COrientation { Portrait, Landscape }
        public COrientation Orientation;

        // Start is called before the first frame update
        void Start()
        {
            if (Orientation == COrientation.Landscape)
            {
                Screen.orientation = ScreenOrientation.LandscapeLeft;
            }
            if (Orientation == COrientation.Portrait)
            {
                Screen.orientation = ScreenOrientation.Portrait;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
