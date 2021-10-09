using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Cutscene : MonoBehaviour
{
    private PlayableDirector cutscene;

    void StartCutscene(GameObject player)
    {

        cutscene.Play();

    }
    
}
