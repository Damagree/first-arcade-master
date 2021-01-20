/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar thread pada Unity menggunakan Invoke
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInvokeRepeating : MonoBehaviour {

    public float StartInvoke;
    public float IntervalSecond;
    public UnityEvent InvokeEvent;
    
    // Use this for initialization
    void Start () {
        InvokeRepeating("LoadInvokeEvent", StartInvoke, IntervalSecond);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadInvokeEvent()
    {
        InvokeEvent.Invoke();
    }
}
