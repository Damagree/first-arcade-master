using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleScale : MonoBehaviour
{
    public string MuzzleLName;
    public string MuzzleRName;
    public GameObject MuzzleL;
    public GameObject MuzzleR;
    public Vector3 ObjectScale;

    // Start is called before the first frame update
    void Start()
    {
        if (MuzzleL)
        {
            MuzzleL.transform.localScale = ObjectScale;
        }
        if (MuzzleR)
        {
            MuzzleR.transform.localScale = ObjectScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!MuzzleL)
        {
            MuzzleL = GameObject.Find(MuzzleLName);
            if (MuzzleL)
            {
                MuzzleL.transform.localScale = ObjectScale;
                MuzzleL.name = "Fix";
            }
        }
        if (!MuzzleR)
        {
            MuzzleR = GameObject.Find(MuzzleRName);
            if (MuzzleR)
            {
                MuzzleR.transform.localScale = ObjectScale;
                MuzzleR.name = "Fix";
            }
        }
    }
}
