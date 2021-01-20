/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar thread pada Unity menggunakan CoRoutine
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventStartCoroutine : MonoBehaviour {

    public float WaitSecond;
    public UnityEvent CoroutineEvent;

    // Use this for initialization
    void Start () {
        StartCoroutine(LoadCoroutineEvent());
	}

    IEnumerator LoadCoroutineEvent()
    {
        yield return new WaitForSeconds(WaitSecond);
        CoroutineEvent.Invoke();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
