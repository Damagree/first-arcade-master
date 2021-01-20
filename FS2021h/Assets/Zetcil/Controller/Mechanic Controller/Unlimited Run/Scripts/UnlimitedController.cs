using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class UnlimitedController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Main Settings")]
        public GameObject TargetObject;

        [Header("Main Settings")]
        public GameObject LeftBackground;
        public GameObject CenterBackground;
        public GameObject RightBackground;

        // Start is called before the first frame update
        void Start()
        {
            CenterBackground.transform.position = LeftBackground.transform.position + new Vector3(LeftBackground.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
            RightBackground.transform.position = CenterBackground.transform.position + new Vector3(CenterBackground.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            if (TargetObject.transform.position.x > (RightBackground.transform.position.x - RightBackground.transform.localScale.x/2))
            {
                LeftBackground.transform.position = RightBackground.transform.position + new Vector3(RightBackground.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
            }
            if (TargetObject.transform.position.x > (LeftBackground.transform.position.x - LeftBackground.transform.localScale.x / 2))
            {
                CenterBackground.transform.position = LeftBackground.transform.position + new Vector3(LeftBackground.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
            }
            if (TargetObject.transform.position.x > (CenterBackground.transform.position.x - CenterBackground.transform.localScale.x / 2))
            {
                RightBackground.transform.position = CenterBackground.transform.position + new Vector3(CenterBackground.GetComponent<SpriteRenderer>().bounds.size.x, 0, 0);
            }
        }
    }
}

