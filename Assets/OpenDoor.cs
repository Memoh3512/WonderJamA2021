using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Sprite closed;
    public Sprite opened;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenSesame()
    {
        transform.GetComponent<SpriteRenderer>().sprite = opened;
        GameObject.FindWithTag("Player").GetComponent<PlayerControls>().lockMovement = false;
    }
}
