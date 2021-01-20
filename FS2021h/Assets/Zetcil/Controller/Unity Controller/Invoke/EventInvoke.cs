/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar thread pada Unity menggunakan Invoke
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInvoke : MonoBehaviour {

    public float WaitSecond;
    public UnityEvent InvokeEvent;

    // Use this for initialization
    void Start () {
        Invoke("LoadInvokeEvent", WaitSecond);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadInvokeEvent()
    {
        InvokeEvent.Invoke();
    }
}
