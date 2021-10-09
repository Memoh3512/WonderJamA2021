using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpookySound : MonoBehaviour
{
    public AudioClip sfx1;
    public AudioClip sfx2;


    public void PlayEvent()
    {

        StartCoroutine(Play());

    }
    
    private IEnumerator Play()
    {

        SoundPlayer.instance.PlaySFX(sfx1);
        yield return new WaitForSeconds(0.2f);
        SoundPlayer.instance.PlaySFX(sfx2, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SoundPlayer.instance.PlaySFX(sfx2, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SoundPlayer.instance.PlaySFX(sfx2, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SoundPlayer.instance.PlaySFX(sfx2, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SoundPlayer.instance.PlaySFX(sfx2, 0.5f);

    }
    
}
