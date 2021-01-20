/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar Instantiae pada Unity 
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThatInstantiateGameObject : MonoBehaviour {

    public GameObject PrefabGameObject;

    [Header("Parent GameObject")]
    public GameObject ThatGameObject;

    // Use this for initialization
    void Start () {
        Instantiate(PrefabGameObject, ThatGameObject.transform.position, ThatGameObject.transform.rotation, ThatGameObject.transform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
