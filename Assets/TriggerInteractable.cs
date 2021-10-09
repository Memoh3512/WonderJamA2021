using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractable : MonoBehaviour
{

    private GameObject ply;
    
    private bool interacted = false;

    public OnInteract onInteract;

    private void Update()
    {
        
        if (ply != null)
        {
            
            if ( !ply.GetComponent<PlayerControls>().lockMovement && !interacted)
            {
                
                onInteract.Invoke(ply);
                Debug.Log("INTERACTED!!!!");
                
            }
            
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Player"))
        {

            ply = other.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Player"))
        {

            ply = null;
        }

    }
}
