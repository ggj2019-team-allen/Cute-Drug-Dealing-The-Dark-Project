using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_WayPoint : MonoBehaviour
{
    private NPC_Doused npcd;
    public Transform[] waypoints;
    
    public float moveSpeed = 2f;

    int waypointIndex = 0;

    bool hasTeleported = false;
    
    void Start()
    {
        
        npcd = GetComponent<NPC_Doused>();

    }

    void Update()
    {
        if (npcd.isDoused == true)
        {

            if(!hasTeleported)
            {
                StartCoroutine(StartTeleport());
                transform.position = waypoints[waypointIndex].transform.position;
                hasTeleported = true;
            }
            
            Move();
        }
    }

    public IEnumerator StartTeleport()
    {
        yield return new WaitForSeconds(0.5f);
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards (transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints [waypointIndex].transform.position)
        {
            waypointIndex += 1; 
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
