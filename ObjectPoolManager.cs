using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{

    Dictionary<int, Queue<ObjectClass.ObjectType>> DicPool = new Dictionary<int, Queue<ObjectClass.ObjectType>>(); //should created a dictionary
    public GameObject newobjec;
    private void Start()
    {
        DicPool.Add(1);
    }







}
