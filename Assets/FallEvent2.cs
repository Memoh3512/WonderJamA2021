using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FallEvent2 : MonoBehaviour
{
    
    private bool eventEnded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LockMovement(GameObject player)
    {

        player.GetComponent<PlayerControls>().lockMovement = true;
        GameObject.Find("Tentacule1").GetComponent<Tentacle>().Startacle();

    }

    

    

    public void EndEvent()
    {

        GameObject.Find("Tentacule1").GetComponent<Tentacle>().Endtacle();
        eventEnded = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().lockMovement = false;
        Destroy(gameObject);

    }
}
