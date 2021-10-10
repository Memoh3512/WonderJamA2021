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
    [SerializeField]
    private List<Transform> waypoints;
    private int targetIndex = -1;
    private Transform target;
    private float lookOffset;
    private bool flipped;

    private void Start()
    {
        GetAllWaypoints();
        GetNextTarget();
        
    }

    void GetAllWaypoints()
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
        newTarget(target.position - transform.position);      

    }

    private void Update()
    {
        Move();

        CheckDistanceWaypoint();

        Look();
    }

    void Look()
    {
          
            transform.right =  Quaternion.Euler(0, 0, lookOffset) * (target.position - transform.position);          
      
    }
    void CheckDistanceWaypoint()
    {

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {

            GetNextTarget();
        }

    }

    public void PlayerSeen()
    {
    
            target = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    void Move()
    {
        if (target == null)        
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);      
    }

    public void newTarget(Vector2 difference)
    {
        //transform.Rotate(new Vector3(0, 0, -lookOffset));
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

        
        
    }
   
}
