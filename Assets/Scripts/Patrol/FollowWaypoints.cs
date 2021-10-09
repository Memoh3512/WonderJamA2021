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
    private SpriteRenderer sR;
    private Transform kid;

    public bool patrol;
    public bool Lookdown;
    public bool backtracking;
    int direction;
    bool playerFound;
    public float speed;
    public float lookSpeed;
    void Start()
    {
        kid = transform.GetChild(0);
        sR = GetComponent<SpriteRenderer>();
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
        float newSpeed = target.GetComponent<Waypoint>().speed;
        if (newSpeed < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            speed = speed * newSpeed;
        }



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
        if (!Lookdown)
        {
            LookTowards();
        }
    }

    void LookTowards()
    {
       
        Vector2 between = target.position - transform.position;
        if (patrol)
        {
            if (between.x < 0)
            {
                sR.flipX = true;
                between = -between;
                if(kid.transform.localRotation.z == 0)
                transform.GetChild(0).transform.Rotate(new Vector3(0,0,180)) ;
            }
            else
            {
                sR.flipX = false;
                if (kid.transform.localRotation.z != 0)
                    transform.GetChild(0).transform.Rotate(new Vector3(0, 0, -180));
            }
        }
        transform.right = Vector2.MoveTowards(transform.right, between, lookSpeed * Time.deltaTime);

    }

    public void PlayerSeen()
    {
        if (!Lookdown)
        {
            speed = speed / target.GetComponent<Waypoint>().speed;
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            CorridorEvent();
        }
    }

    void CorridorEvent()
    {

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneChanger.GameOver();
        }
    }
}
