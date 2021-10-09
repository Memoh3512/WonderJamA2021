﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{

    public TextMeshProUGUI text;

    public AudioClip displaySFX;
    // Start is called before the first frame update
    void Start()
    {

        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

    }

    public void DisplayText(string displayText, float nbSecs = 2f, bool playSound = true)
    {
        
        StopAllCoroutines();
        
        if (playSound && displaySFX != null) SoundPlayer.instance.PlaySFX(displaySFX);
        
        StartCoroutine(TextDisplayCor(displayText, nbSecs));


    }

    IEnumerator TextDisplayCor(string displayText, float nbSecs = 2f)
    {

        text.text = displayText;

        //fade in
        while (text.color.a < 1)
        {
            
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + Time.deltaTime);
            yield return null;

        }
        
        yield return new WaitForSeconds(nbSecs);

        //fade out
        while (text.color.a > 0)
        {
            
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.deltaTime);
            yield return null;

        }
        

    }
    
}
