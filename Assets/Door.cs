using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool KeyGotten;
    public void GotKey()
    {
        KeyGotten = true;
    }

    public void Interact(GameObject player)
    {
        if (KeyGotten)
        {
            OpenDoor();
        }
        else
        {
            DoorLockedText();
        }

        player.GetComponent<PlayerControls>().lockMovement = false;
    }

    void OpenDoor()
    {
        //ouvrage de porte lol.<
        Destroy(gameObject);
    }

    void DoorLockedText()
    {
        GameObject.Find("UIText").GetComponent<UIText>().DisplayText("The door is locked dumbass, find the hecking key >:(");
    }

}
