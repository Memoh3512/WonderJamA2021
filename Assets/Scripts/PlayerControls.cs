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

    public bool lockMovement = false;

    private void Awake()
    {
        
        GetPlayerGamepad();   
        
    }

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void GetPlayerGamepad()
    {

        manette = PlayerInputs.GetPlayerController(0);
        if (Gamepad.current is null) manette = new Manette();
        else manette = new Manette(Gamepad.current);

    }
    
    private void FixedUpdate()
    {
        if (!lockMovement) MovePlayer();

    }

    void MovePlayer()
    {
        
        var position = transform.position;
        rb.MovePosition(new Vector2(position.x,position.y)+(manette.leftStick * (Time.deltaTime * speed)));

    }

    public Manette GetManette()
    {

        return manette;

    }
}
