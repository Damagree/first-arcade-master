/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar Instantiae pada Unity 
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstantiateGameObject : MonoBehaviour
{

    public GameObject PrefabGameObject;

    [Header("Parent GameObject")]
    public GameObject ParentGameObject;
    public bool DetachFromParent;

    public void InstantiateGameObject()
    {
        GameObject temp = Instantiate(PrefabGameObject, ParentGameObject.transform.position, ParentGameObject.transform.rotation, ParentGameObject.transform);
        if (DetachFromParent)
        {
            temp.transform.parent = null;
        }
    }

    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
