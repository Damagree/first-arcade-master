/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar Instantiae pada Unity 
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisInstantiateGameObject : MonoBehaviour
{

    public GameObject PrefabGameObject;

    // Use this for initialization
    void Start()
    {
        Instantiate(PrefabGameObject, this.transform.position, this.transform.rotation, this.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
