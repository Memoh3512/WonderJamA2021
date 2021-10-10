using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPlugWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UnPlugged()
    {
        Debug.Log("WIN!");
        SceneChanger.ChangeScene(SceneTypes.Win);
    }
}
