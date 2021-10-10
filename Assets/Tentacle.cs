using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Startacle()
    {
        StartCoroutine(Tentacling());
    }

    IEnumerator Tentacling()
    {
        float time = 10;
        yield return null;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
