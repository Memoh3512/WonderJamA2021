using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Controls;


public enum QTEButton
{
    
    a,b,left,right,up,down
    
}

public class QTE : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onSucceed;
    [SerializeField]
    public QTEButton boutonToPress;

    public float timeToPress;

    public int spamCount = 1;

    private ButtonControl button;

    private PlayerControls player;
    
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindObjectOfType<PlayerControls>();
        
        switch (boutonToPress)
        {
            
            case QTEButton.a:

                button = player.GetManette().aButton;
                
                break;
            case QTEButton.b:

                button = player.GetManette().bButton;
                
                break;
            case QTEButton.down:

                button = player.GetManette().lJoyDown;
                
                break;
            case QTEButton.left:

                button = player.GetManette().lJoyLeft;
                
                break;
            case QTEButton.right:

                button = player.GetManette().lJoyRight;
                
                break;
            case QTEButton.up:

                button = player.GetManette().lJoyUp;
                
                break;
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartQTE()
    {

        StartCoroutine(QTECor());

    }


    IEnumerator QTECor()
    {
        
        while (spamCount > 0)
        {
            if (button.wasPressedThisFrame)          
                spamCount--;      
            else
                yield return null;



        }

        //end QTE
        onSucceed.Invoke();

    }

}
