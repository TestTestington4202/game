using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement : MonoBehaviour {
    public float Walkspeed;
   


	// Use this for initialization
	void Start ()
    {
        Walkspeed = 10f;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime*Walkspeed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * Walkspeed);
	}
}
