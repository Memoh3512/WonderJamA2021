using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Light_Flicker : MonoBehaviour
{
    public float timeFlash=0.25f;
    [Range(30f,60f)]
    public float often = 30;
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

            if (timeLeftFlash<timeFlash*0.2&&Random.Range(0, (int)(10*(-often+100) * (1 / Time.deltaTime)/often*timeFlash))==0)
            {
                light.enabled = false;
                timeLeftFlash=Random.Range(-timeFlash * 0.5f + timeFlash, timeFlash * 0.5f + timeFlash);
            }
            
            if (timeLeftFlash > 0)
            {
                timeLeftFlash -= Time.deltaTime;
                if (timeLeftFlash <= 0)
                {
                    light.enabled = true;
                    if (sound != null) sound.Pause();
                    
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
  
    // Update is called once per frame
    void Update()
    {
        Flash(true);
    }
}
