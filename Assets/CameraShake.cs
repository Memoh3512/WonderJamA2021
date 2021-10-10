using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    private CinemachineBasicMultiChannelPerlin noise;
    
    // Start is called before the first frame update
    void Start()
    {

        vcam = GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin> ();


        //ShakeCam(2f,1f,5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShakeCam(float time, float amp, float freq, RumbleForce force = RumbleForce.Medium)
    {

        if (Gamepad.current != null)
        {
            
            Manette manTemp = new Manette(Gamepad.current);
            manTemp.Rumble(time, force);

        }
        
        StartCoroutine(ShakeCamCor(time, amp, freq));   

    }

    private IEnumerator ShakeCamCor(float time, float amp, float freq)
    {

        Noise(amp, freq);
        yield return new WaitForSeconds(time);
        Noise(0,0);


    }
    
    public void Noise(float amplitudeGain, float frequencyGain)
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_AmplitudeGain = amplitudeGain;
             
        noise.m_FrequencyGain = frequencyGain;
        noise.m_FrequencyGain = frequencyGain;
        noise.m_FrequencyGain = frequencyGain;      
 
    }
    
}
