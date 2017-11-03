using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testobject :PoolObject
{
     void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * 3;
        transform.Translate(Vector3.forward * Time.deltaTime * 25);    
    }


    public override void OnObjectReuse()
    {
        transform.localScale = Vector3.one;
    }

}
