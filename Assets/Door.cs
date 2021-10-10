using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool KeyGotten;

    public string popUp;
    public OnInteract onOpen;
    public void GotKey()
    {
        KeyGotten = true;
    }

    public void Interact(GameObject player)
    {
        if (KeyGotten)
        {
            OpenDoor(player);
        }
        else
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerControls>().lockMovement = false;
            DoorLockedText();
            player.GetComponent<PlayerControls>().lockMovement = false;
        }

       
    }

    void OpenDoor(GameObject player)
    {
        //ouvrage de porte lol.<
        onOpen.Invoke(player);
        
       // Destroy(gameObject);
    }

    void DoorLockedText()
    {
        GameObject.Find("UIText").GetComponent<UIText>().DisplayText(popUp);
    }

}
