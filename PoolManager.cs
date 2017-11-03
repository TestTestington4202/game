using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    //creating a new pool




    Dictionary<int, Queue<ObjectInstance>> poolDictionary = new Dictionary<int, Queue<ObjectInstance>>(); // creating a dictionary for the queue

    static PoolManager _instance;

    public static PoolManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<PoolManager>();

            }
            return _instance;
        }
    }

    public void CreatePool(GameObject prefab, int poolSize)                     //creating a qecue, need access to a dictionary
    {
        int poolKey = prefab.GetInstanceID();
        GameObject PoolHolder = new GameObject(prefab.name + "pool");
        PoolHolder.transform.parent = transform;

        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<ObjectInstance>());       //adds in the new object into the queue

            for(int i = 0; i < poolSize; i++)
            {
                ObjectInstance newObject = new ObjectInstance(Instantiate(prefab) as GameObject); //instantiate new prefab
     
                poolDictionary[poolKey].Enqueue(newObject);
                newObject.SetParent(PoolHolder.transform);

            }


        }

    }


    public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation)  //this reuses object in the game
    {
        int poolKey = prefab.GetInstanceID();
        if(poolDictionary.ContainsKey(poolKey))
        {
            ObjectInstance objectToReuse = poolDictionary[poolKey].Dequeue();
            poolDictionary[poolKey].Enqueue(objectToReuse);

            objectToReuse.Reuse(position, rotation);

        }



    }



    public class ObjectInstance
    {
        GameObject gameobject;
        Transform transform;

        bool hasPoolObjectComponent;
        PoolObject poolObjectScript;

        public ObjectInstance(GameObject objectInstance)
        {
            gameobject = objectInstance;
            transform = gameobject.transform;
            gameobject.SetActive(false);

            if (gameobject.GetComponent<PoolObject>())
            {
                hasPoolObjectComponent = true;
                poolObjectScript = gameobject.GetComponent<PoolObject>();
            }



        }

        public void Reuse(Vector3 position, Quaternion rotation)
        {
            
            gameobject.SetActive(true);
            transform.position = position;            //set the poition
            transform.rotation = rotation;            //set the rotation
            if (hasPoolObjectComponent)
            {
                poolObjectScript.OnObjectReuse();

            }




        }
        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }

    }





}
