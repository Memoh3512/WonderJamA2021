using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloaking : MonoBehaviour
{
    public static bool cloakUnlocked = false;
    private int chargesLeft;
    private bool cloakToggled;
    private PlayerControls pC;
    private SpriteRenderer sR;

    public void UnlockCloak()
    {
        
        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        cloakToggled = false;
        chargesLeft = 2;
        sR = GetComponent<SpriteRenderer>();
        pC = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cloakUnlocked)
        {
            if (pC.GetManette().bButton.wasPressedThisFrame)
            {
                ToggleCloak();
            }
        }
        
    }

    void ToggleCloak()
    {
        if (!cloakToggled && chargesLeft > 0)
        {
            StartCoroutine(Cloak());
        }
    }

    IEnumerator Cloak()
    {
        cloakToggled = true;
        pC.lockMovement = true;
        sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 0.49f);
        yield return null;
        while (!pC.GetManette().bButton.wasPressedThisFrame)
        {
            yield return null;
        }
        sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 1);
        chargesLeft--;
        cloakToggled = false;
        pC.lockMovement = false;


    }
}
