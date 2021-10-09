using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioClip sfx;

    public void PlaySFX(float volume)
    {
        
        if (sfx != null) SoundPlayer.instance.PlaySFX(sfx,volume);
        
    }

}
