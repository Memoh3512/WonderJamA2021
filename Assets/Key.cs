using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string popUpText;
    public List<Door> doorScripts;
    // Start is called before the first frame update
    void Start()
    {
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
        foreach (var doorScript in doorScripts)
        {
            doorScript.GotKey();
        }
    }

    void GetKey()
    {
        GameObject.Find("UIText").GetComponent<UIText>().DisplayText(popUpText);
        Destroy(gameObject);
    }
}
