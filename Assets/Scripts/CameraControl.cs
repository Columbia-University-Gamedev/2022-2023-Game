using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{ 
    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/
    //There's a bunch of code in this file that was initially used to control the angle of the camera for a 3D game, so some of it is completely useless, 
    //I will at some point go through and make it cleaner
     
     
    public float mainSpeed = 30.0f; //regular speed

    private float totalRun= 1.0f;
     
    void Update () {

       
        Vector3 p = GetBaseInput();
        if (p.sqrMagnitude > 0){ // only move while a direction key is pressed
          if (Input.GetKey (KeyCode.LeftShift)){
              totalRun += Time.deltaTime;
          } else {
              totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
              p = p * mainSpeed;
          }
         
          p = p * Time.deltaTime;
          Vector3 newPosition = transform.position;
          if (Input.GetKey(KeyCode.Space)){ //If player wants to move on X and Z axis only
              transform.Translate(p);
              newPosition.x = transform.position.x;
              newPosition.z = transform.position.z;
              transform.position = newPosition;
          } else {
              transform.Translate(p);
          }
        }
    }
     
    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 1 , 0);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, -1, 0);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
