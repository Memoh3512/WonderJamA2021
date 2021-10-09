using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public string popUpText;
    private Door doorScript;
    // Start is called before the first frame update
    void Start()
    {
        doorScript = door.GetComponent<Door>();
    }

    // Update is called once per frame
    public void Interact(GameObject player)
    {
        UnlockDoor();
        GetKey();

        player.GetComponent<PlayerControls>().lockMovement = false;

    }

    void UnlockDoor()
    {
        doorScript.GotKey();
    }

    void GetKey()
    {
        GameObject.Find("UIText").GetComponent<UIText>().DisplayText(popUpText);
        Destroy(gameObject);
    }
}
