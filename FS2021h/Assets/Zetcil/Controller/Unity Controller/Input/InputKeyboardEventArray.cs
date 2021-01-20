/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputKeyboardEventArray : MonoBehaviour
{

    [System.Serializable]
    public class CKeyboardArray{
        public KeyCode InputKeyDown;
        public UnityEvent KeyDownEvent;

        [Space(10)]
        public KeyCode InputKey;
        public UnityEvent KeyEvent;

        [Space(10)]
        public KeyCode InputKeyUp;
        public UnityEvent KeyUpEvent;
    }

    public List<CKeyboardArray> KeyboardArray;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < KeyboardArray.Count; i++)
        {
            if (Input.GetKeyDown(KeyboardArray[i].InputKeyDown))
            {
                KeyboardArray[i].KeyDownEvent.Invoke();
            }
            if (Input.GetKey(KeyboardArray[i].InputKey))
            {
                KeyboardArray[i].KeyEvent.Invoke();
            }
            if (Input.GetKeyUp(KeyboardArray[i].InputKeyUp))
            {
                KeyboardArray[i].KeyUpEvent.Invoke();
            }
        }
    }
}
