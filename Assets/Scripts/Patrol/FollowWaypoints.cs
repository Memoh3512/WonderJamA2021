using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<Transform> waypoints;
    private int targetIndex;
    private Transform target;

    public bool backtracking;
    int direction;
    bool playerFound;
    public float speed;
    public float lookSpeed;
    void Start()
    {
        GetAllWaypoints();
        targetIndex = -1;
        direction = 1;
        GetNextTarget();
        playerFound = false;

    }

    
    void GetAllWaypoints()
    {
        waypoints = new List<Transform>();
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Waypoint").Length; i++)
        {
            waypoints.Add(GameObject.Find($"Waypoint ({i})").transform);
        }
        
    }

    void GetNextTarget()
    {
        if (direction > 0)
        {
            if (targetIndex < waypoints.Count - 1)
            {
                targetIndex += direction;
            }
            else if (!backtracking)
            {
                targetIndex = 0;
            }
            else 
            {
                direction = -1;
                targetIndex += direction;

            }


        }
        else
        {
            if (targetIndex == 0)
            {
                direction = 1;
               
            }

            targetIndex += direction;
        }



        if(target != null)
        speed = speed / target.GetComponent<Waypoint>().speed;
        target = waypoints[targetIndex];
        speed = speed * target.GetComponent<Waypoint>().speed;



    }

    void CheckDistanceWaypoint()
    {

       if(Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            GetNextTarget();
        }

    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        LookTowards();
    }

    void LookTowards()
    {
        Vector2 between = target.position - transform.position;

        transform.right = Vector2.MoveTowards(transform.right, between, lookSpeed * Time.deltaTime);
    }

    public void PlayerSeen()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    

    // Update is called once per frame
    void Update()
    {
        Move();
        if (!playerFound)
        {         
            CheckDistanceWaypoint();
        }
        
    }
}
