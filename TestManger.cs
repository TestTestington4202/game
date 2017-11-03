using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManger : MonoBehaviour {

    public GameObject prefab;


    void Start()
    {
        PoolManager.instance.CreatePool(prefab, 30);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PoolManager.instance.ReuseObject(prefab, Vector3.zero, Quaternion.identity);


        }
    }
}
