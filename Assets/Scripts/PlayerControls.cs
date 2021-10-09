using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerControls : MonoBehaviour
{

    private Manette manette;
    private Rigidbody2D rb;
    public float speed = 1f;

    private bool lockMovement = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetPlayerGamepad();
    }

    public void GetPlayerGamepad()
    {

        manette = PlayerInputs.GetPlayerController(0);

    }
    
    private void FixedUpdate()
    {
        if (!lockMovement) MovePlayer();

    }

    void MovePlayer()
    {
        
        var position = transform.position;
        rb.MovePosition(new Vector2(position.x,position.y)+(manette.leftStick*Time.deltaTime*speed));

    }
}
