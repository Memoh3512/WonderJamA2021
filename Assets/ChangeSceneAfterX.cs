using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneAfterX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SceneTimer());

    }

    private IEnumerator SceneTimer()
    {

        yield return new WaitForSeconds(11.5f);
        SceneChanger.ChangeScene(SceneTypes.GameOver);

    }
}
