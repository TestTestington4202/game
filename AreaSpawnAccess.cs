using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawnAccess : MonoBehaviour {

    public GameObject[] AreaObjectaccess;               //allow the user to access the object that should be spawned in this area.
    public GameObject[] blach;
    public int[] ObjectSpawnedCount;
    protected int Arraysize;
    private int CurrentObject;                          //current object being spawned
    public int maxObject;
    private int count=0;                                //

    private GameObject[] PointSpawn;                     //location of the empty gameobject

    public string tags ="Blank";                                  //string of emptygameobject tag

    public bool Spoint;
    public bool Sarea;


    private float colider_X;                                                      //creates a variable for the size of the clider in the X direction
    private float colider_Z;                                                      //creates a variables for the size of the colider in the Z direction

    Vector3 POStoSpawn ;

    // Use this for initialization
    void Start ()
    {
     
        Arraysize = AreaObjectaccess.Length;            //grabs the array length of acreaObjectaccess
        ObjectSpawnedCount = new int[Arraysize];        //should always set the count array to the size of the gameobject array
        PointSpawn = GameObject.FindGameObjectsWithTag(tags);

        if (Sarea == true)                                                        //this only works if Sarea is true for area Spawn
        {
            Spoint = false;                                                       //turns off Spoint just to make sure its not on
      
            colider_X = this.GetComponent<Collider>().bounds.size.x;              //grabs the bound of the object colider in the x direction
            colider_Z = this.GetComponent<Collider>().bounds.size.z;              //grabs the bound of the object colider in the Z direction
            RaycastHit hit;                                                       //holds the variables for the distance of the ground
            Ray Ray = new Ray(this.transform.position, Vector3.down);             //creates a ray to determine the distance to the ground.
            Debug.DrawRay(this.transform.position, Vector3.down * 10, Color.red); //make the red line to check the distance of the ray cast
            Physics.Raycast(Ray, out hit, 10);                                    //cast ray to hit the ground
           
            POStoSpawn.y = hit.transform.position.y;                              //set the postion of the y for POStoSpawn
        }
        else if(Spoint == true)
        {
            Sarea = false;
        
        }

        


    }

    // dealing with ridgedbodys
    void Update()
    {





        if (count < maxObject && Sarea == true)
        {

         
            CurrentObject = Random.Range(0, Arraysize);     //random item spawn
            POStoSpawn.x = this.transform.position.x;
            POStoSpawn.z = this.transform.position.z;
            POStoSpawn.x += Random.Range(-colider_X, colider_X); //set a random spot for the object to spawn
            POStoSpawn.z += Random.Range(-colider_Z, colider_Z);
            ObjectSpawnedCount[CurrentObject] += 1;         //keeps track of item that spawned reletive to the array AreaObjectaccess
            Instantiate(AreaObjectaccess[CurrentObject], POStoSpawn, Quaternion.identity);   //spanw in the object
            count++;                                        //increment the total amount of object spawned

        }
        else if (count < PointSpawn.Length && Spoint == true)
        {
            for (int i = 0; i < PointSpawn.Length; i++)
            {
                CurrentObject = Random.Range(0, Arraysize);
                ObjectSpawnedCount[CurrentObject] += 1;
                Instantiate(AreaObjectaccess[CurrentObject], PointSpawn[i].transform.position, Quaternion.identity);
                count++;
            }


        }
        else
            enabled = false;
    }

    


    private void OnTriggerEnter(Collider other)
    {
        
        if(GameObject.FindGameObjectWithTag("AI"))
        {

            if (other.GetComponent<ObjectAccess>().AllowedObject != AreaObjectaccess)
            {
                other.GetComponent<ObjectAccess>().AllowedObject = AreaObjectaccess;
                other.GetComponent<ObjectAccess>().NumAllowedObject = ObjectSpawnedCount;
                print("New object Accessed");
            }
            else
                print("No change to objects");
         

        }







    }



}
