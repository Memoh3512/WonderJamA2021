using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FallEvent2 : MonoBehaviour
{
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

    }

    public void EndEvent()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().lockMovement = false;
        GameObject.FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 7;
        Destroy(gameObject);

    }
}
