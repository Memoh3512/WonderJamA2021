using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantSpeed : MonoBehaviour
{
    public Vector3 x=new Vector3(-2,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += x*Time.deltaTime;
    }
}
