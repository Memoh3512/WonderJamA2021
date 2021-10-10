using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiviereEvent : MonoBehaviour
{
    public SpriteRenderer button;
    private PlayerControls pC;
    // Start is called before the first frame update
    void Start()
    {
        pC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
        pC.lockMovement = true;
        button.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndCutscene()
    {
        pC.lockMovement = false;
        //pC.transform.position = pC.transform.position + new Vector3(-2, 0, 0);
        button.enabled = false;
        GetComponent<Collider2D>().enabled = true;
    }

    public void GameOver()
    {
        SceneChanger.GameOver();
    }
}
