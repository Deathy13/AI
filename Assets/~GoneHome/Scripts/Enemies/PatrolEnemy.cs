using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace YouKnowTheWay
{
    public class PatrolEnemy : MonoBehaviour
    {
        public Transform waypointGroup;
        public float movementSpeed = 10f;
        //how close the enemy needs to be to switch waypoints
        public float closeness = 1f;
        private Transform[] waypoint;
        private int currentIndex = 0;



        // Use this for initialization
        void Start()
        {
            int length = waypointGroup.childCount;
            waypoint = new Transform[length];
            //// for (initialization;  condition; iteration)
            for (int i = 0; i < length; i++)
            {
                waypoint[i] = waypointGroup.GetChild(i);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //get the current waypoint
            Transform current = waypoint[currentIndex];
            // move the enemy towards current waypoint
            Vector3 position = transform.position;
            Vector3 direction = current.position - position;
            position += direction.normalized * movementSpeed * Time.deltaTime;
            //all new postion to transform
            transform.position = position;

            // Get distance to current waypoint
            float distance = Vector3.Distance(position, current.position);
            // Is the enemy close to current waypoint?
            if (distance <= closeness)
            {
                //switch to next waypoint
                currentIndex++;
            }
           //cheack if curent indext >= length (2)
           if(currentIndex >= waypoint.Length)
            {
                //loop back around to first waypoint
                currentIndex = 0;
            }

        }
    }
}
