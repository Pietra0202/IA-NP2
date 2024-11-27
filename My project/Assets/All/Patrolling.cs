using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    private int targetPoint = 0;

    void Start()
    {
        targetPoint = 0;
    }


    void Update()
    {

        if (transform.position == waypoints[targetPoint].position)
        {
            targetPoint = (targetPoint + 1) % waypoints.Length;
        }

        //transform.position = Vector3.MoveTowards(transform.position, waypoints[targetPoint].position, speed * Time.deltaTime);
    }
}
