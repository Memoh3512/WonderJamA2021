using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXAfterX : MonoBehaviour
{

    public AudioClip sfx;
    public float delay = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCor());
    }

    private IEnumerator DelayCor()
    {

        yield return new WaitForSeconds(delay);
        SoundPlayer.instance.PlaySFX(sfx);

    }
}
