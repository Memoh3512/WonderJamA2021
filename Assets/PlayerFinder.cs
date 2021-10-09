using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    // Start is called before the first frame update
    FollowWaypoints fW;
    void Start()
    {
        fW = transform.parent.GetComponent<FollowWaypoints>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            fW.PlayerSeen();
        }
    }
}
