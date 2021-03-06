using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneTypes
{
    
    PlayerJoin = 0,
    GameplayScene = 1,
    GameOver = 2,
    IntroCutscene = 3,
    FinalLevel = 4,
    Win = 5,
    
}

public enum TransitionTypes
{
    
    CrossFade,
    CoolTransition,
    
}

public class SceneChanger : MonoBehaviour
{

    public SceneTypes nextScene = 0;
    public TransitionTypes transition;

    public void ChangeScene()
    {

        LevelLoader.instance.LoadScene(nextScene, transition);

    }
    
    public static void ChangeScene(SceneTypes scene, TransitionTypes transitionType = TransitionTypes.CrossFade)
    {

        
        LevelLoader.instance.LoadScene(scene, transitionType);

    }

    public static void GameOver()
    {
        
        LevelLoader.instance.LoadScene(SceneTypes.GameOver, TransitionTypes.CrossFade);
        
    }

}
