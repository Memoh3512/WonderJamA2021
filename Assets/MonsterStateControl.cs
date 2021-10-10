using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateControl : MonoBehaviour
{
    public GameObject leftMonster;
    public GameObject rightMonster;
    public GameObject upMonster;
    public GameObject downMonster;
    public float speed;
    public float lookSpeed;
   
    public List<Transform> waypoints;
    private int targetIndex = -1;
    private Transform target;
    private float lookOffset;
    private bool flipped;
    private bool playerFound;
    private float baseSpeed;

    private void Start()
    {
        baseSpeed = speed;
        if (waypoints.Count == 0)
        {
            GetAllWaypoints();
        }
        GetNextTarget();
        
    }

    public void GetAllWaypoints()
    {
        waypoints = new List<Transform>();
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Waypoint").Length; i++)
        {
            waypoints.Add(GameObject.Find($"Waypoint ({i})").transform);
           
        }

    }

    public  void GetNextTarget()
    {
      
            if (targetIndex < waypoints.Count - 1)
            {
            targetIndex++;
            }
            else 
            {
                targetIndex = 0;
            }


        target = waypoints[targetIndex];
        if(target.GetComponent<Waypoint>().speed < 0)
        {
            LockerEventEnd();
        }
        newTarget(target.position - transform.position);      

    }

    private void Update()
    {
        if (waypoints.Count > 0)
        {
            Move();

            CheckDistanceWaypoint();

            Look();
        }
    }

    void Look()
    {
          
            transform.right = Vector2.MoveTowards(transform.right,Quaternion.Euler(0, 0, lookOffset) * (target.position - transform.position),lookSpeed*Time.deltaTime);          
      
    }
    void CheckDistanceWaypoint()
    {

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            if (playerFound)
            {
                SceneChanger.GameOver();
            }
            else
            {
                GetNextTarget();
            }
        }

    }

    public void PlayerSeen()
    {
    
            target = GameObject.FindGameObjectWithTag("Player").transform;
            speed = baseSpeed*2;
       
    }

    void Move()
    {
        if (target != null)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void newTarget(Vector2 difference)
    {
        transform.right = Quaternion.Euler(0, 0, -lookOffset) * transform.right;
        leftMonster.SetActive(false);
        rightMonster.SetActive(false);
        upMonster.SetActive(false);
        downMonster.SetActive(false);

        if(Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
        {
            if(difference.x > 0)
            {
                rightMonster.SetActive(true);
                lookOffset = 0;
            }
            else
            {
                leftMonster.SetActive(true);
                lookOffset = 180;
            }
        }
        else
        {
            if(difference.y > 0)
            {
                upMonster.SetActive(true);
                lookOffset = -90;
            }
            else
            {
                downMonster.SetActive(true);
                lookOffset = 90;
            }


        }

        transform.right = Quaternion.Euler(0, 0, lookOffset) * transform.right;


    }

    void LockerEventEnd()
    {
        Destroy(GameObject.Find("LockerWaypoints"));
        Destroy(gameObject);
    }
   
}
