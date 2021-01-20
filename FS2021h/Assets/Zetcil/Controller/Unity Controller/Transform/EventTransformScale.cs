/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTransformScale : MonoBehaviour
{

    public GameObject ThatGameObject;
    public Vector3 IncrementScale;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTransformScale()
    {
        ThatGameObject.transform.localScale += IncrementScale;
    }

    public void SetTransformScaleX(float aX)
    {
        ThatGameObject.transform.localScale += new Vector3(aX, 0, 0);
    }

    public void SetTransformScaleY(float aY)
    {
        ThatGameObject.transform.localScale += new Vector3(0, aY, 0);
    }

    public void SetTransformScaleZ(float aZ)
    {
        ThatGameObject.transform.localScale += new Vector3(0, 0, aZ);
    }

}
