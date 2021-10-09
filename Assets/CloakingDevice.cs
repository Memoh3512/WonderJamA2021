using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakingDevice : MonoBehaviour
{
    public void PickUpCloakingDevice(GameObject player)
    {
        player.GetComponent<Cloaking>().UnlockCloak();
        GameObject.Find("UIText").GetComponent<UIText>().DisplayText("You picked up a cloaking device");
        Destroy(gameObject);
    }
}
