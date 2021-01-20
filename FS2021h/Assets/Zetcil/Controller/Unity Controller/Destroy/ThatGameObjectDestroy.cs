/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar Destroy pada Unity 
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThatGameObjectDestroy : MonoBehaviour
{
    public GameObject ThatGameObject;
    public float DestroyTime;

    // Use this for initialization
    void Start()
    {
        Destroy(ThatGameObject.gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
