using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEntry : MonoBehaviour
{

    private void Start()
    {

        //ajouter le clavier aux manettes
        PlayerInputs.gamepads.Add(new Manette());
        
        foreach (Gamepad gp in Gamepad.all)
        {
            
            PlayerInputs.gamepads.Add(new Manette(gp));
            
        }
        
        InputSystem.onDeviceChange += (device, change) =>
        {

            switch (change)
            {
                
                case InputDeviceChange.Added :
                    if (!ManetteContains((Gamepad)device))
                    {
                        
                        PlayerInputs.gamepads.Add(new Manette((Gamepad)device));
                        Debug.Log("ADDED DEVICE " + device.displayName);   
                        
                    }
                    break;
                case InputDeviceChange.Removed:
                    RemoveManette((Gamepad)device);
                    break;
                    
                
            }

        };
        
        
    }

    private void Update()
    {
        
        //Debug.Log("WE HAVE " + PlayerInputs.gamepads.Count + " GAMEPADS!");
        foreach (Manette man in PlayerInputs.gamepads)
        {

            if (man.joinButton.wasPressedThisFrame && (!PlayerInputs.pControllers.Contains(man)))
            {
                man.Rumble(0.5f, RumbleForce.Medium);
                PlayerInputs.AddPlayerController(man);
                
                //Debug.Log("START GAME");
                SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("Sound/SFX/Press button_VF"), 0.7f);
                SceneChanger.ChangeScene(SceneTypes.IntroCutscene, TransitionTypes.CrossFade);
                
            }
            
        }
        
    }

    private bool ManetteContains(Gamepad gp)
    {

        bool contains = false;
        foreach (Manette man in PlayerInputs.gamepads)
        {

            if (man.gp == gp) contains = true;

        }

        return contains;

    }

    private void RemoveManette(Gamepad gp)
    {

        Manette toRemove = null;
        foreach (Manette man in PlayerInputs.gamepads)
        {

            if (man.gp == gp) toRemove = man;

        }

        if (toRemove != null) PlayerInputs.gamepads.Remove(toRemove);

    }
}
