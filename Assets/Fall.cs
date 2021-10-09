using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public SpriteRenderer button;
    private PlayerControls pC;
    private bool activated;
    // Start is called before the first frame update
    void Start()
    {
        pC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
        button.enabled = false;
    }


    void FallEventStart()
    {
        GetComponent<Cutscene>().StartCutscene(pC.gameObject);
        pC.lockMovement = true;
        button.enabled = true;
    }

    public void EndEvent()
    {
        pC.lockMovement = false;
        button.enabled = false;
    }

    public void GameOver()
    {
        SceneChanger.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated)
        {
            if(collision.tag == "player")
            {
                FallEventStart();
            }
        }
    }
}
