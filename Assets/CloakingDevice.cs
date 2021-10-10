using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakingDevice : MonoBehaviour
{
    public void PickUpCloakingDevice(GameObject player)
    {
        player.GetComponent<Cloaking>().UnlockCloak();
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/Pickup item_V01"), 1.5f);
        GameObject.Find("UIText").GetComponent<UIText>().DisplayText("You picked up a cloaking device (F/B button to turn invisible). Has 3 charges",8f);
        Destroy(gameObject);
    }
}
