using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateControl : MonoBehaviour
{
    public GameObject leftMonster;
    public GameObject rightMonster;
    public GameObject upMonster;
    public GameObject downMonster;

   
    public void newTarget(Vector2 difference)
    {
        leftMonster.SetActive(false);
        rightMonster.SetActive(false);
        upMonster.SetActive(false);
        downMonster.SetActive(false);

        if(Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
        {
            if(difference.x > 0)
            {
                rightMonster.SetActive(true);
            }
            else
            {
                leftMonster.SetActive(true);
            }
        }
        else
        {
            if(difference.y > 0)
            {
                upMonster.SetActive(true);
            }
            else
            {
                downMonster.SetActive(true);
            }

        }
        
    }
   
}
