/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTransformPosition : MonoBehaviour
{

    public GameObject ThatGameObject;
    public Vector3 IncrementPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransformPosition()
    {
        ThatGameObject.transform.position += IncrementPosition;
    }

    public void SetTransformPositionX(float aX)
    {
        ThatGameObject.transform.position += new Vector3(aX, 0, 0);
    }

    public void SetTransformPositionY(float aY)
    {
        ThatGameObject.transform.position += new Vector3(0, aY, 0);
    }

    public void SetTransformPositionZ(float aZ)
    {
        ThatGameObject.transform.position += new Vector3(0, 0, aZ);
    }

}
