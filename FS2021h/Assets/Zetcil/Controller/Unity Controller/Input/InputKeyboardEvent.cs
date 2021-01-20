/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputKeyboardEvent : MonoBehaviour
{

    public KeyCode InputKeyDown;
    public UnityEvent KeyDownEvent;

    [Space(10)]
    public KeyCode InputKey;
    public UnityEvent KeyEvent;

    [Space(10)]
    public KeyCode InputKeyUp;
    public UnityEvent KeyUpEvent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InputKeyDown))
        {
            KeyDownEvent.Invoke();
        }
        if (Input.GetKey(InputKey))
        {
            KeyEvent.Invoke();
        }
        if (Input.GetKeyUp(InputKeyUp))
        {
            KeyUpEvent.Invoke();
        }
    }
}
