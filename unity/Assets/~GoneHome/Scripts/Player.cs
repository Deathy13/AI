using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GoneHome
{
    public class Player : MonoBehaviour
    {
        public float maxVelocity = 10f;
        private Transform cam;
        public float movementSpeed = 10f;
        private Rigidbody rigid;
        private Vector3 spawnPoint;
        public GameObject deathParticles;




        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            cam = Camera.main.transform;
            spawnPoint = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            
            Vector3 inputDir = new Vector3(inputH, 0, inputV);
            inputDir = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up) * inputDir;
            rigid.AddForce(inputDir * movementSpeed);
            Vector3 vel = rigid.velocity;
            //cheack if vel 
            if(vel.magnitude > maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }
        }
        public void Reset()
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            transform.position = spawnPoint;
            rigid.velocity = Vector3.zero;
        }
    }

}