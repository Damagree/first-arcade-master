/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar Raycast pada Unity 
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour {

    public Camera MainCamera;

    [Header("Screen Position")]
    public Vector2 ScreenPosition;

    [Header("World Position")]
    public Vector3 WorldPosition;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        ScreenPosition = Input.mousePosition;

        Ray ray = MainCamera.ScreenPointToRay(ScreenPosition);
        RaycastHit raycastHit3D;

        if (Physics.Raycast(ray, out raycastHit3D))
        {
            WorldPosition = raycastHit3D.point;
            Debug.DrawRay(MainCamera.transform.position, raycastHit3D.point, Color.red);
        }

    }
}
