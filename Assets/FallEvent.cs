using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEvent : MonoBehaviour
{
    public GameObject egout;

    public float unitsTasse = 1f;

    public AudioClip egoutTassage;
    public AudioClip fallClip;
    public AudioClip splashClip;

    public CanvasGroup fadeOut;

    public Transform tpPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEvent(GameObject player)
    {

        StartCoroutine(EventCor(player));

    }

    IEnumerator EventCor(GameObject player)
    {
        
        player.GetComponent<PlayerControls>().lockMovement = true;
        
        //jouer son egout tassage
        SoundPlayer.instance.PlaySFX(egoutTassage);
        
        //tasser egout
        Vector3 target = egout.transform.position + new Vector3(unitsTasse,0);
        while (Vector2.Distance((Vector2)target,(Vector2)transform.position) > 0.1f)
        {

            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime*0.8f);
            yield return null;

        }
        //fade out
        while (fadeOut.alpha < 1)
        {

            fadeOut.alpha += Time.deltaTime;
            yield return null;

        }

        fadeOut.alpha = 1;
        
        //fall sound
        SoundPlayer.instance.PlaySFX(fallClip);
        //wait
        yield return new WaitForSeconds(3f);
        
        //splash
        SoundPlayer.instance.PlaySFX(splashClip);
        
        //tp joueur
        player.transform.position = tpPos.position;
        
        //wait
        yield return new WaitForSeconds(2f);
        

        //fade in
        while (fadeOut.alpha > 0f)
        {

            fadeOut.alpha -= Time.deltaTime;
            yield return null;

        }

        fadeOut.alpha = 0;

        player.GetComponent<PlayerControls>().lockMovement = false;


    }
    
}
