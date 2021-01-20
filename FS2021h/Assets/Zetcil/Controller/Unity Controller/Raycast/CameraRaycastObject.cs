/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar Raycast pada Unity 
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycastObject : MonoBehaviour
{

    public Camera MainCamera;

    [Header("Screen Position")]
    public Vector2 ScreenPosition;

    [Header("World Position")]
    public Vector3 WorldPosition;

    [Header("GameObject Information")]
    public string GameObjectName;
    public string GameObjectTag;
    public Vector3 GameObjectPosition;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ScreenPosition = Input.mousePosition;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = MainCamera.ScreenPointToRay(ScreenPosition);
            RaycastHit raycastHit3D;

            if (Physics.Raycast(ray, out raycastHit3D))
            {
                WorldPosition = raycastHit3D.point;
                GameObjectName = raycastHit3D.transform.name;
                GameObjectTag = raycastHit3D.transform.tag;
                GameObjectPosition = raycastHit3D.transform.position;
            }
        }
    }
}
