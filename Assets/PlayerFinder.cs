using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    // Start is called before the first frame update
    MonsterStateControl mSC;
    void Start()
    {
        mSC = transform.parent.parent.GetComponent<MonsterStateControl>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mSC.PlayerSeen();
        }
    }
}
