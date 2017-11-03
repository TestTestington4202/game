using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.Characters.ThirdPerson //pulling in thirdperson assets
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Animator))]


    public class BotKyle : MonoBehaviour
    {

        public float animator_speed = 1.5f;  //set the general speed of the bot


        //animation curve
        public bool AnimationCurve;                                 //allows the usage of Curves in the animiation
        
        //grab animator 
        private Animator animator;
        private AnimatorStateInfo currentBaseState;
        private AnimatorStateInfo layer2CurrentState;
        private CapsuleCollider cap_Col;

        static int idleState = Animator.StringToHash("Base Layer.Idle");
        static int locoState = Animator.StringToHash("Base Layer.Locomotion");


        // Use this for initialization
        void Start()
        {
            //to initialize some of the variables
            animator = GetComponent<Animator>();
            cap_Col = GetComponent<CapsuleCollider>();
            if (animator.layerCount == 2)
                animator.SetLayerWeight(1,1);
        }

        //using fixedupdated because the bot is using a ridigbody
        void FixedUpdate()
        {

            float Dirction_h = Input.GetAxis("Horizontal");              //this sets up the variable for direction
            float Dirction_v = Input.GetAxis("Vertical");                //this sets up the variable for speed
            animator.SetFloat("Direction", Dirction_h);                  //this grabs the Direction parameter for the variable direction_h
            animator.SetFloat("Speed", Dirction_v);                      //This grabs the speed paramerter for the variables direction_v
            animator.speed = animator_speed;                             //set the animator speed to a public variable
            currentBaseState = animator.GetCurrentAnimatorStateInfo(0);  //sets the current state variables to the base layer of the animation






        }
    }


}