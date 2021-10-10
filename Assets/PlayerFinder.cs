using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    // Start is called before the first frame update
    MonsterStateControl mSC;
    private bool seen = false;
    private GameObject ply;
    void Start()
    {
        ply = GameObject.FindWithTag("Player");
        mSC = transform.parent.parent.GetComponent<MonsterStateControl>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            ply = collision.gameObject;
            if (NothingInView(collision.gameObject) && !seen)
            {
                
                mSC.PlayerSeen();
                seen = true;

            }
            
        }
    }

    private bool NothingInView(GameObject player)
    {

        Ray ray = new Ray(transform.position, (player.transform.position - transform.position));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized,8.5f, 1 << 6);
        return hit.collider.tag == "Player";

    }

    private void OnDrawGizmos()
    {
        
        //Gizmos.DrawRay(transform.position, (ply.transform.position - transform.position).normalized*8.5f);
        
    }
}
