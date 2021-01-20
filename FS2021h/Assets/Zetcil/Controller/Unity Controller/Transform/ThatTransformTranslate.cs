/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThatTransformTranslate : MonoBehaviour
{

    public enum CTranslate { VectorUp, VectorDown, VectorForward, VectorBack, VectorLeft, VectorRight }
    public GameObject ThatGameObject;
    public CTranslate TranslateType;
    public float Speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (TranslateType)
        {
            case CTranslate.VectorUp:
                ThatGameObject.transform.Translate(Vector3.up * Speed * Time.deltaTime);
                break;
            case CTranslate.VectorDown:
                ThatGameObject.transform.Translate(Vector3.down * Speed * Time.deltaTime);
                break;
            case CTranslate.VectorForward:
                ThatGameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                break;
            case CTranslate.VectorBack:
                ThatGameObject.transform.Translate(Vector3.back * Speed * Time.deltaTime);
                break;
            case CTranslate.VectorLeft:
                ThatGameObject.transform.Translate(Vector3.left * Speed * Time.deltaTime);
                break;
            case CTranslate.VectorRight:
                ThatGameObject.transform.Translate(Vector3.right * Speed * Time.deltaTime);
                break;
        }
    }
}
