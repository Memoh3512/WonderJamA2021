using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialTimer : MonoBehaviour
{
    public AudioClip clip;
    private float cliptime = 6f;
    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(IndustrialTimerCor());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IndustrialTimerCor()
    {
        yield return new WaitForSeconds(1f);
        SoundPlayer.instance.PlaySFX(clip);
        yield return new WaitForSeconds(cliptime);
        SceneChanger.ChangeScene(SceneTypes.GameplayScene);
        


    }
    
}
