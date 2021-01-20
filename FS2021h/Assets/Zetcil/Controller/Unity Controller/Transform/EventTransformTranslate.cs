/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTransformTranslate : MonoBehaviour
{

    public enum CTranslate { VectorUp, VectorDown, VectorForward, VectorBack, VectorLeft, VectorRight }
    public GameObject ThatGameObject;
    [HideInInspector]
    public CTranslate TranslateType;
    public float Speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTransformTranslateVectorUp()
    {
        ThatGameObject.transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    public void SetTransformTranslateVectorDown()
    {
        ThatGameObject.transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    public void SetTransformTranslateVectorLeft()
    {
        ThatGameObject.transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    public void SetTransformTranslateVectorRight()
    {
        ThatGameObject.transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    public void SetTransformTranslateVectorForward()
    {
        ThatGameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    public void SetTransformTranslateVectorBack()
    {
        ThatGameObject.transform.Translate(Vector3.back * Speed * Time.deltaTime);
    }


}
