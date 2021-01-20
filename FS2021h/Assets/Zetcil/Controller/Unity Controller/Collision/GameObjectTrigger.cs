/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar deteksi tabrakan GameObject pada Unity
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTrigger : MonoBehaviour
{

    public Rigidbody NeedRigidbody;

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
        Debug.Log("Collision With: " + collider.transform.name + " Tag: " + collider.transform.tag);
    }
}
