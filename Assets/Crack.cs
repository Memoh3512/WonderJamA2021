using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Crack : MonoBehaviour
{
    public GameObject crack;
    public GameObject fond;
    public GameObject monster;
    public GameObject pressA;
    private PlayerControls pC;

    public float monsterOffset;
    // Start is called before the first frame update
    void Start()
    {
        crack.SetActive(false);
        fond.SetActive(false);
        monster.SetActive(false);
        pressA.SetActive(false);
        pC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }


    public void StartCrack()
    {
        pC.lockMovement = true;
        crack.SetActive(true);
        fond.SetActive(true);
        pressA.SetActive(true);
        StartCoroutine(Advance());
    }



    IEnumerator Advance()
    {
        yield return null;
        while (!pC.GetManette().aButton.wasPressedThisFrame)
        {
            yield return null;
        }

        pressA.SetActive(false);
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/FitCrack"),1); 
        while (FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize  > 6f)
        {
            FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize -= Time.deltaTime;
            yield return null;
        }
        
        yield return new WaitForSeconds(1);
        pressA.SetActive(true);

        while (!pC.GetManette().aButton.wasPressedThisFrame)
        {
            yield return null;
        }

        pressA.SetActive(false);

        while (FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize > 4f)
        {
            FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize -= Time.deltaTime;
            yield return null;
        }
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/FitCrack"), 1);
        yield return new WaitForSeconds(0.9f);
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/Jumpscare_V01"), 1);
        yield return new WaitForSeconds(0.1f);

        monster.SetActive(true);
        monsterOffset = monster.transform.position.x - fond.transform.position.x;
        StartCoroutine(FootStepsMonster());
        yield return new WaitForSeconds(0.25f);

        while (!pC.GetManette().aButton.wasPressedThisFrame)
        {
            monster.transform.position += Vector3.left * Time.deltaTime*3f;
                                     
            yield return null;
        }
        if (Mathf.Abs(monster.transform.position.x - fond.transform.position.x) < 7f)
        {
            SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/FitCrack"), 1);
            yield return new WaitForSeconds(2f);         
            StartCoroutine(GameOver());
        }
        else
        {
            pC.gameObject.transform.position += 7*Vector3.right ;
            StartCoroutine(Finish());
        }

       

    }

    IEnumerator GameOver()
    {
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/Monster scream_VF"), 1);
        yield return new WaitForSeconds(5);
        SceneChanger.GameOver();
    }

    IEnumerator Finish()
    {
        while(fond.GetComponent<SpriteRenderer>().color.a > 0)
        {
            Color col = fond.GetComponent<SpriteRenderer>().color;
            fond.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, col.a - Time.deltaTime);
            crack.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, col.a - Time.deltaTime);
            yield return null;
        }
        FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 7;
        crack.SetActive(false);
        fond.SetActive(false);
        pC.lockMovement = false;

        

    }

    IEnumerator FootStepsMonster()
    {
        float vol;
        while (Mathf.Abs(monster.transform.position.x - fond.transform.position.x) < monsterOffset+0.3f)
        {

            if (monster != null)
            {

                vol = (monsterOffset - Mathf.Abs(monster.transform.position.x - transform.position.x)) / monsterOffset;
                vol = Mathf.Max(0, vol);
                Debug.Log(vol);

            }
            else
            {

                vol = 0f;

            }
            SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/Pas robot_VF"), vol);

            yield return new WaitForSeconds(1f);

        }
        monster.SetActive(false);
        

    }
}
