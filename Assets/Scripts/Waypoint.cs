using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
        if(speed == 0)
        {
            speed = 1;
        }
    }
}
