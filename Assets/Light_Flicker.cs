using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light_Flicker : MonoBehaviour
{
    public float timeFlash=0.25f;
    [Range(0.0f,200.0f)]
    public float often = 100;
    [Range(0.5f,2.0f)]
    public float oftenMod = 0.9f;
    private Light2D light;
    private float timeLeftFlash=0;
    public GameObject particleSystem=null;
    private Light2D currLight;

    public AudioSource sound;
    void Start()
    {
        light=transform.GetComponent<Light2D>();

        Flash(true);

    }
    private bool Flash(bool reset)
    {
        if (reset)
        {

            if (timeLeftFlash<timeFlash*0.2&&Random.Range(0, (int)(often * oftenMod - (often / 2))) == 0)
            {
                light.enabled = true;
                timeLeftFlash=Random.Range(-timeFlash * 0.3f + timeFlash, timeFlash * 0.3f + timeFlash);
            }
            
            if (timeLeftFlash > 0)
            {
                timeLeftFlash -= Time.deltaTime;
                if (timeLeftFlash <= 0)
                {
                    ToggleOffLight(light);
                    if (particleSystem!=null)
                    {
                        particleSystem.SetActive(false);
                    }

                    timeLeftFlash = 0;
                }

                return true;
            }
        }
        return false;
    }
    private void ToggleOffLight(Light2D light)
    {
        light.enabled = false;
        if (sound != null) sound.Pause();
    }
    // Update is called once per frame
    void Update()
    {
        Flash(true);
    }
}
