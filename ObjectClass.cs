using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClass : MonoBehaviour {

    
    public class ObjectType
    {                                   //need to change public to private later
        public GameObject gameobject;
        public Transform objectTransform;
        public string Type = "blank";

        

        public ObjectType(GameObject CurrentObject)
        {
            gameobject = CurrentObject;                     //set the gameobject
            objectTransform = gameobject.transform;         //set the current transform
                                                            //  gameobject.SetActive(false);
            Type = gameobject.tag;
            

        }

    }





}
