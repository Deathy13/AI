using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace GoneHome
{
    public class FollowEnemy : MonoBehaviour
    {
        private Vector3 spawnPoint;
        private Quaternion spawnRotation;
        public Transform target;
        private NavMeshAgent agent;

        // Use this for initialization
        void Start()
        {

            spawnPoint = transform.position;
            spawnRotation = transform.rotation;
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(target.position);
        }
        public void Reset()
        {
            agent.enabled = false;
            transform.position = spawnPoint;
            transform.rotation = spawnRotation;
            agent.enabled = true;
        }

    }
}
