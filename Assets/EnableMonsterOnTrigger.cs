using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMonsterOnTrigger : MonoBehaviour
{
    public MonsterStateControl monsterStateControl;
    public BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        monsterStateControl.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            monsterStateControl.gameObject.SetActive(true);
            monsterStateControl.enabled = true;
        }
    }
}
