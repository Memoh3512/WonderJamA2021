using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FallEvent2 : MonoBehaviour
{
    private bool eventEnded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LockMovement(GameObject player)
    {

        player.GetComponent<PlayerControls>().lockMovement = true;
        StartCoroutine(Zoom());
    }

    IEnumerator Zoom()
    {
        while (FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize > 1.3f || !eventEnded)
        {
            FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize -= Time.deltaTime*0.57f;
            yield return null;
        }

        while(FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize < 7f)
        {
            FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize -= Time.deltaTime * 5f;
        }
        FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 7;
    }

    

    public void EndEvent()
    {
        eventEnded = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().lockMovement = false;
        GameObject.FindObjectOfType<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 7;
        Destroy(gameObject);

    }
}
