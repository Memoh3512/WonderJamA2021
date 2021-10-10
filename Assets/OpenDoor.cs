using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Sprite closed;
    public Sprite opened;
    private GameObject closedCollider;
    private GameObject openedCollider;
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
        Invoke("CloseSesame",2f);
        
    }
    private void CloseSesame()
    {
        transform.GetComponent<SpriteRenderer>().sprite = closed;
        GameObject.FindWithTag("Player").GetComponent<PlayerControls>().lockMovement = false;
        openedCollider.GetComponent<BoxCollider2D>().enabled=false;
        closedCollider.GetComponent<BoxCollider2D>().enabled=true;
    }
}
