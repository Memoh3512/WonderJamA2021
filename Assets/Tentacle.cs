using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Tentacle : MonoBehaviour
{
    private bool ended;
    SpriteRenderer sR;
    public GameObject child1;
    public GameObject child2;
    private void Start()
    {

        child1.SetActive(false);
        child2.SetActive(false);
        sR = GetComponent<SpriteRenderer>();
        sR.enabled = false;
    }
    public void Startacle()
    {
       
        StartCoroutine(Tentacling());
        StartCoroutine(Zoom());
        StartCoroutine(Sounds());
    }

    public void Endtacle()
    {
        ended = true;


    }
    IEnumerator Sounds()
    {
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/Jumpscare_V01"), 1);
        yield return new WaitForSeconds(0.5f);
        child1.SetActive(true);
        child2.SetActive(true);
        sR.enabled = true;
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/Monster scream_VF"), 0.5f);  
        yield return new WaitForSeconds(1.5f);
        while (!ended)
        {
            SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/Pas robot_VF"), 1);
            yield return new WaitForSeconds(1.5f);
        }
            
    }
    IEnumerator Tentacling()
    {       
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
       
        while (transform.position.x < 35.8f && !ended)
       {
            transform.position += Vector3.right*Time.deltaTime * 1.3f;
            yield return null;
       }
       
       while(transform.position.x > 5)
        {
            transform.position -= Vector3.right * Time.deltaTime * 5f;
            yield return null;
        }

        Destroy(gameObject);


    }

    IEnumerator Zoom()
    {
        
        while (FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize > 1.3f  && !ended)
        {
            FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize -= Time.deltaTime * 0.57f;
            yield return null;
        }

        while (FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize < 7f)
        {
           
            FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize += Time.deltaTime * 2f;
            yield return null;
        }
        FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 7;

    }



}
