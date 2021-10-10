using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MonsterPeekaboo : MonoBehaviour
{

    public GameObject MonsterPrefab;

    public GameObject player;
    public Vector3 monsterOffset;
    public float monsterSpeed;
    private GameObject monster;

    public AudioClip monsterScream;

    public GameObject canvas1, canvas2;

    public float nearnessTreshold;

    private bool monsterPass = true;

    public AudioClip monsterStepClip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPeekaboo()
    {
        
        StartCoroutine(PeekabooCor());
        StartCoroutine(FootStepsMonster());
        

    }

    IEnumerator FootStepsMonster()
    {
        float vol;
        while (monsterPass)
        {

            if (monster != null)
            {

                vol = (monsterOffset.x - Math.Abs(monster.transform.position.x - transform.position.x)) / monsterOffset.x;
                vol = Math.Max(0, vol);
                Debug.Log(vol);

            }
            else
            {

                vol = 0f;

            }
            SoundPlayer.instance.PlaySFX(monsterStepClip, vol);
            
            yield return new WaitForSeconds(1f);

        }
        
    }

    private IEnumerator PeekabooCor()
    {

        yield return new WaitForSeconds(1f);
        
        monster = Instantiate(MonsterPrefab, player.transform.position + monsterOffset, Quaternion.identity);
        
        while (!player.GetComponent<PlayerControls>().GetManette().aButton.wasPressedThisFrame)
        {

            monster.transform.position += new Vector3(-Time.deltaTime * monsterSpeed, 0);
            yield return null;

        }

        monsterPass = false;
        
        //check conditions
        float x = monster.transform.position.x - player.transform.position.x;
        if (x <= -nearnessTreshold || x >= nearnessTreshold)
        {
            
            //Succeed and close event
            GetComponent<Interactable>().enabled = false;
            player.GetComponent<PlayerControls>().lockMovement = false;
            Destroy(canvas1);
            Destroy(canvas2);
            Destroy(monster);
            monster = null;
            GameObject.FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 7;
            SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/Ouverture boite_VF"));

        }
        else
        {
            
            //play scream monster and gameover
            SoundPlayer.instance.PlaySFX(monsterScream, 1.0f);
            yield return new WaitForSeconds(1f);
            SceneChanger.GameOver();

        }

    }
    
    
}
