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
    private Collider2D collider;
    
    public GameObject cloakUI;

    public void UnlockCloak()
    {
        cloakUnlocked = true;
        
        cloakUI.SetActive(true);
        pC.lockMovement = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (cloakUI != null) cloakUI.SetActive(false);
        collider = GetComponent<Collider2D>();
        cloakToggled = false;
        chargesLeft = 3;
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
        GameObject.Find($"Charge{chargesLeft}").SetActive(false);
        chargesLeft--;
        sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 0.49f);
        collider.enabled = false;
        yield return null;
        while (!pC.GetManette().bButton.wasPressedThisFrame)
        {
            yield return null;
        }
        collider.enabled = true;
        sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 1);
        cloakToggled = false;
        pC.lockMovement = false;


    }
}
