using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    private SoundEffects sfx;

    public void PlaySFX(float volume)
    {
        
        SoundPlayer.instance.PlaySFX(sfx,volume);
        
    }

}
