using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class OpenDoor : MonoBehaviour
{
    public Sprite closed;
    public Sprite opened;
    private GameObject closedCollider;
    private GameObject openedCollider;
    public Light2D green;
    public Light2D red;
    // Start is called before the first frame update
    void Start()
    {
        closedCollider = transform.Find("ClosedCollider").gameObject;
        openedCollider = transform.Find("OpenedCollider").gameObject;
        CloseSesame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenSesame()
    {
        transform.GetComponent<SpriteRenderer>().sprite = opened;
        GameObject.FindWithTag("Player").GetComponent<PlayerControls>().lockMovement = false;
        openedCollider.GetComponent<BoxCollider2D>().enabled=true;
        closedCollider.GetComponent<BoxCollider2D>().enabled=false;
        green.enabled = true;
        red.enabled = false;
        Invoke("CloseSesame",2f);
        
    }
    private void CloseSesame()
    {
        transform.GetComponent<SpriteRenderer>().sprite = closed;
        GameObject.FindWithTag("Player").GetComponent<PlayerControls>().lockMovement = false;
        openedCollider.GetComponent<BoxCollider2D>().enabled=false;
        closedCollider.GetComponent<BoxCollider2D>().enabled=true;
        red.enabled = true;
        green.enabled = false;
    }
}
