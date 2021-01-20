/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar deteksi tabrakan GameObject pada Unity
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectCollisionEvent : MonoBehaviour
{

    public Rigidbody NeedRigidbody;
    public string GameObjectTargetTag;
    public UnityEvent CollisionEvent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == GameObjectTargetTag)
        {
            CollisionEvent.Invoke();
        }
    }

}
