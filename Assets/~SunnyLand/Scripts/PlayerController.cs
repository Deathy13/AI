using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SunnyLand
{
    public class PlayerController : MonoBehaviour
    {
        #region variables
        public float speed = 5f;
        public int health = 100;
        public int damage = 50;
        public float hitForce = 4f;
        public float damageForce = 4;
        public float maxVelocity = 3f;
        public float maxSlopeAngle = 45f;
        [Header("grounding")]
        public float rayDistance = 0.5f;
        public bool isGrounded = false;
        [Header("Crouch")]
        public bool isCrouching = false;
        [Header("jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;
        [Header("climb")]
        public float climbeSpeed = 5f;
        public bool isClimbing = false;
        public bool isOnSlope = false;
        private Vector3 GroundNourmal = Vector3.up;
        private int currentJump = 0;
        private float inputH, inputV;
        private SpriteRenderer rend;
        private Rigidbody2D rigid;
        #endregion
        #region Unity Function
        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            performJump();
            performMove();
            PerfromClimb();
        }
        void FixedUpdate()
        {
            DetectGround();
            CheckSlope();
        }
        void OnDrawGizmos()
        {
            //draw the ground ray
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
            //Draw Direction
            Vector3 right = Vector3.Cross(GroundNourmal, Vector3.forward);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position - right * 1f,
                            transform.position + right * 1f);


        }
        #endregion
        #region Custom Functions
       
        private void PerfromClimb()
        {

        }
        private void performMove()
        {//calculate the move direction base of the surface
            Vector3 right = Vector3.Cross(GroundNourmal, Vector3.forward);
            //add forec in direcdtion using horizantoal
            rigid.AddForce(right * inputH * speed);
            // limit the velocity to max velocity
            LimitVelocity();
        }
        private void performJump()
        {
            //are we jumping
            if(isJumping)
            {//are we allowed to jump?
                 if(currentJump < maxJumpCount)
                {//increment jump by 1
                    currentJump++;rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
                 //jump is finished!
                isJumping = false;
            }
        }
        public void Jump()
        {
            isJumping = true;
        }
        public void Crouch()
        {

        }
        public void UnCrouch()
        {

        }
        public void Move(float horizontal)
        {
            if(horizontal != 0)
            {
                rend.flipX = horizontal < 0;
            }
            inputH = horizontal;
        }
        public void Climb(float vertical)
        {

        }
        public void Hurt(int damage)
        {

        }

        private void DetectGround()
        {
            //create a ground ray
            Ray graundRay = new Ray(transform.position, Vector3.down);
            //shoot ray below the lpayer and get all hits
            RaycastHit2D[] hits = Physics2D.RaycastAll(graundRay.origin, graundRay.direction, rayDistance);
            // loop through all hits
            foreach (var hit in hits)
            {//cheack if we hit the ground
                CheckEnemy(hit);
                //check if we hit the ground
               if( CheckGround(hit))
                {//exit the loop
                    break;
                }
            }
        }
        private void CheckSlope()
        {
            if(isOnSlope)
            {
                rigid.drag = 5f;
            }
            else
            {
                rigid.drag = 0f;
            }
        }
        private bool CheckGround(RaycastHit2D hit)
        {      // exists                   is not the player               is not a trigger
            if(hit.collider != null && hit.collider.name != name && hit.collider.isTrigger == false)
            { //reset the jump
                currentJump = 0;
                //player is in the ground state
                isGrounded = true;
                //update the ground normal
                GroundNourmal = hit.normal;
                //check for slops
                float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
                isOnSlope = Mathf.Abs(slopeAngle) > 0 && Mathf.Abs(slopeAngle) < maxSlopeAngle;
                //if we reached the max slope angle
                if(slopeAngle >+ maxSlopeAngle)
                {
                    //push the player down
                    // slope (by adding mor gravity
                    rigid.AddForce(Physics2D.gravity);
                }
                // cheack if we entered a sloop




                //returen true (ground is found)

                return true;
            }
            //return fales ! (ground is not found)
            return false;
        }
        private void CheckEnemy(RaycastHit2D hit)
        {

        }
        private void LimitVelocity()
        {//chache rigid velocity in smal variable
            Vector3 vel = rigid.velocity;
            //if vel length is greather than max velocity
            if(vel.magnitude > maxVelocity)
            {//cap the velocity to maxVelocity
                vel = vel.normalized * maxVelocity;
            }//apply newly calcultion vel to rigidbody
            rigid.velocity = vel;
        }
        private void StopClimbing()
        {

        }
        private void DisablePhysics()
        {

        }
        private void EnablePhysics()
        {

        }
        #endregion
    }
}