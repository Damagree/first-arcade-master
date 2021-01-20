/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script Hello World
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        Debug.Log("Awake: Hello World");
    }

    void Start () {
        Debug.Log("Start: Hello World");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update: Hello World");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Fixed Update: Hello World");
    }

    void LateUpdate()
    {
        Debug.Log("Late Update: Hello World");
    }

    public void ShowHelloUnity()
    {
        Debug.Log("Event: Hello World");
    }
}
