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

    public void Interact()
    {
        if (KeyGotten)
        {
            OpenDoor();
        }
        else
        {
            DoorLockedText();
        }
    }

    void OpenDoor()
    {
        //ouvrage de porte lol.
    }

    void DoorLockedText()
    {
        GameObject.Find("UIText").GetComponent<UIText>().DisplayText("The door is locked dumbass, find the hecking key >:(");
    }

}
