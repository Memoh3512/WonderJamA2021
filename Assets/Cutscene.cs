using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Cutscene : MonoBehaviour
{
    private int i = 0;
    private PlayableDirector cutscene;
    public TimelineAsset[] timelines;

    public void StartCutscene(GameObject player)
    {

        cutscene.playableAsset = timelines[0];
        cutscene.Play();

    }

    public void NextTimeline()
    {

        i++;
        cutscene.Stop();
        if (i < timelines.Length)
        {
            
            cutscene.playableAsset = timelines[i];
            cutscene.Play();

        }

    }
    
}
