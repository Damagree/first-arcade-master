using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTo : MonoBehaviour
{

    public Transform ThisPosition;
    public Transform ThatPosition;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ThisPosition.position = Vector3.Lerp(ThisPosition.position, ThatPosition.position, Speed * Time.deltaTime);
    }
}
