/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar deteksi tabrakan GameObject pada Unity
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectTriggerEvent : MonoBehaviour
{

    public Rigidbody NeedRigidbody;
    public string GameObjectTargetTag;
    public UnityEvent TriggerEvent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == GameObjectTargetTag)
        {
            TriggerEvent.Invoke();
        }
    }

}
