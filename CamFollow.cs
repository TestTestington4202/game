using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public GameObject CamPOS;
    public Camera Maincam;
    Transform MaincamPosition;
   
    public bool Follow = false;

	// Use this for initialization
	void Start ()
    {
        CamPOS = GameObject.Find("CAM_POS");
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Follow == true)
        {
            Maincam.transform.position = CamPOS.transform.position;
            Maincam.transform.rotation = CamPOS.transform.rotation;
        }



		
	}
}
