using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MonsterLightFlicker : MonoBehaviour
{
    public float timeFlash;
    [Range(0.0f,200.0f)]
    public float often = 100;
    [Range(0.5f,2.0f)]
    public float oftenMod = 0.5f;
    private List<Light2D> lights = new List<Light2D>();
    private List<float> timeLeftFlash = new List<float>();
    public GameObject parent;
    private Light2D currLight;

    public AudioSource sound;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GetAllLights();
        Flash(true);
        
    }
    private void GetAllLights()
    {
        foreach (Light2D light in parent.GetComponentsInChildren<Light2D>())
        {
            lights.Add(light);
            timeLeftFlash.Add(0f);
            light.enabled = false;
        }
    }
    private bool Flash(bool reset)
    {
        if (reset)
        {

            if (Random.Range(0, (int)(often * oftenMod - (often / 2))) == 0)
            {
                timeLeftFlash[ToggleOnNewLight()]=Random.Range(-timeFlash * 0.3f + timeFlash, timeFlash * 0.3f + timeFlash);
            }
            for (int i = 0; i < lights.Count; i++)
            {
                if (timeLeftFlash[i] > 0)
                {
                    timeLeftFlash[i] -= Time.deltaTime;
                    if (timeLeftFlash[i] <= 0)
                    {
                        ToggleOffLight(lights[i]);
                        timeLeftFlash[i] = 0;
                    }

                    return true;
                }
                else if (timeLeftFlash[i] > 0)
                    return true;
            }
        }
        return false;
    }
    private int ToggleOnNewLight()
    {
        int x = Random.Range(0, lights.Count);
        if (lights[x].enabled == false)
        {
            currLight=lights[x];
            currLight.enabled=true;
            if (sound != null) sound.UnPause();
        }
        return x;
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
