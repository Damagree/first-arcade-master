/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTransformRotation : MonoBehaviour
{

    public GameObject ThatGameObject;
    public Vector3 IncrementRotation;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransformRotation()
    {
        ThatGameObject.transform.Rotate(IncrementRotation);
    }

    public void SetTransformRotationX(float aX)
    {
        ThatGameObject.transform.Rotate(aX, 0, 0);
    }

    public void SetTransformRotationY(float aY)
    {
        ThatGameObject.transform.Rotate(0, aY, 0);
    }

    public void SetTransformRotationZ(float aZ)
    {
        ThatGameObject.transform.Rotate(0, 0, aZ);
    }

    public void SetFixTransformRotationY(float aY)
    {
        Vector3 temp = ThatGameObject.transform.localRotation.eulerAngles;
        temp.y = aY;
        ThatGameObject.transform.rotation = Quaternion.Euler(temp);
    }

}
