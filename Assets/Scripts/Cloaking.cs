using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloaking : MonoBehaviour
{
    public Material cloak;
    private Material baseMaterial;
    private int chargesLeft;
    private PlayerControls pC;
    private SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        baseMaterial = sR.material;
        pC = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
