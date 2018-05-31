using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace TowerDefense
{
    public class AIAgent : MonoBehaviour
    {
        public Transform target;
        private NavMeshAgent nav;

        // Use this for initialization
        void Start()
        {
            nav = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            if(target)
            {
                nav.SetDestination(target.position);
            }

        }
    }
}