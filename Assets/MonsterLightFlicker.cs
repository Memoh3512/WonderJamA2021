using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MonsterLightFlicker : MonoBehaviour
{
    public float timeFlash=30f;
    [Range(30f,95f)]
    public float often = 100;
    private List<Light2D> lights = new List<Light2D>();
    private List<float> timeLeftFlash = new List<float>();
    private List<GameObject> particleSystems = new List<GameObject>();
    public GameObject parent;
    private Light2D currLight;

    public AudioSource sound;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GetAllLights();
        Flash(true);
        foreach (var particleSystem in particleSystems)
        {
            particleSystem.SetActive(false);
        }
        
    }
    private void GetAllLights()
    {
        foreach (Light2D light in parent.GetComponentsInChildren<Light2D>())
        {
            lights.Add(light);
            timeLeftFlash.Add(0f);
            if (light.transform.childCount > 0)
            {
                particleSystems.Add(light.transform.GetChild(0).gameObject);
            }
            light.enabled = false;
        }
    }
    private bool Flash(bool reset)
    {
        if (reset)
        {
            float random = Random.Range(0, (int)(10*(-often+100) * (1 / Time.deltaTime)/often*timeFlash));
            if (random==0)
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
                        if (particleSystems.Count > 0)
                        {
                            particleSystems[i].SetActive(false);
                        }
                        
                        timeLeftFlash[i] = 0;
                    }

                    return true;
                }else if (timeLeftFlash[i] > 0)
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
            currLight.enabled = true;
            if (particleSystems.Count > 0)
            {
                particleSystems[x].SetActive(true);
            }
            if (sound != null) sound.UnPause();
        }
        return x;
    }
    private void ToggleOffLight(Light2D light)
    {
        light.enabled = false;
        if (sound != null) sound.Pause();
    }
    // Update is called once per frame, penis
    void Update()
    {
        Flash(true);
    }
}
