/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar deteksi tabrakan GameObject pada Unity
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectCollision : MonoBehaviour {

    public Rigidbody NeedRigidbody;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision With: " + collision.transform.name + " Tag: " + collision.transform.tag);
    }
}
