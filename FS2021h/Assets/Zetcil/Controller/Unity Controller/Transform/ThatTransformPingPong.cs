/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity khususnya toggle direction position (Ping Pong)
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThatTransformPingPong : MonoBehaviour
{

    public GameObject ThatGameObject;
    public float Speed;
    public Vector3 IncrementPosition;
    Vector3 StartPosition;
    Vector3 EndPosition;

    // Use this for initialization
    void Start()
    {
        StartPosition = ThatGameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * Speed, 1);
        EndPosition = StartPosition + IncrementPosition;
        ThatGameObject.transform.position = Vector3.Lerp(StartPosition, EndPosition, pingPong);
    }
}
