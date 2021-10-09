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

    private ButtonControl button;

    public PlayerControls player;
    
    // Start is called before the first frame update
    void Start()
    {

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

        while (!button.wasPressedThisFrame)
        {
            
            yield return null;   
            
        }

        //end QTE
        onSucceed.Invoke();

    }

}
