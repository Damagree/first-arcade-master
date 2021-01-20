/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboardDebug : MonoBehaviour {

    public KeyCode InputKeyDown;
    public KeyCode InputKey;
    public KeyCode InputKeyUp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(InputKeyDown))
        {
            Debug.Log("KeyDown: " + InputKeyDown);
        }
        if (Input.GetKey(InputKey))
        {
            Debug.Log("Key: " + InputKey);
        }
        if (Input.GetKeyUp(InputKeyUp))
        {
            Debug.Log("KeyUp: " + InputKeyUp);
        }
    }
}
