using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallMovement : MonoBehaviour {

    /* 

     bool upArrow = false;
     bool pushedUpArrow = false;
     bool downArrow = false;
     bool pushedDownArrow = false;
     bool leftArrow = false;
     bool pushedLeftArrow = false;
     bool rightArrow = false;
     bool pushedRightArrow = false;

     
     private float accelerationForce;*/

    public float maxAccelerationForce;
    public float acceleration;
    private float accelerationForce;

    public float maxJumpForce;
    private bool jump = false;
    private bool jumpDone = true;

    private GameObject thisGO;
    private Rigidbody thisRB;

    public float jumpDelay;



    void Start ()
    {
        thisGO = GameObject.FindGameObjectWithTag("Player");
        thisRB = thisGO.GetComponent<Rigidbody>();        
    }
	
	void Update ()
    {
        CheckForInput();
        ApplyForce();
    }

    void CheckForInput()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (accelerationForce < maxAccelerationForce)
            {
                accelerationForce += acceleration;
            }
            else
            {
                accelerationForce = maxAccelerationForce;
            }         
        }

        if (Input.GetKey(KeyCode.DownArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false)
        {
            if (accelerationForce > 0)
            {
                accelerationForce -= acceleration;
            }
            else
            {
                accelerationForce = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)&& jumpDone == true)
        {
            StartCoroutine("WaitForJump");
            jump = true;
            jumpDone = false;
        }

        //down arrow
        /*  if (Input.GetKeyDown(KeyCode.DownArrow))
          {
              downArrow = true;

          }
          if (Input.GetKeyUp(KeyCode.DownArrow))
          {
              downArrow = false;

          }
          //uparrow
          if (Input.GetKeyDown(KeyCode.UpArrow))
          {
              upArrow = true;
          }
          if (Input.GetKeyUp(KeyCode.UpArrow))
          {
              upArrow = false;
          }
          //leftarrow
          if (Input.GetKeyDown(KeyCode.LeftArrow))
          {
              leftArrow = true;
          }
          if (Input.GetKeyUp(KeyCode.LeftArrow))
          {
              leftArrow = false;
          }
          //rightarrow
          if (Input.GetKeyDown(KeyCode.RightArrow))
          {
              rightArrow = true;
          }
          if (Input.GetKeyUp(KeyCode.RightArrow))
          {
              rightArrow = false;
          }*/
    }

    void ApplyForce()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (thisRB != null)
        {
            if (jump == true)
            {
                Vector3 movement = new Vector3(horizontalMovement * accelerationForce, maxJumpForce, verticalMovement * accelerationForce);
                thisRB.AddForce(movement);
                jump = false;
            }
            else
            {
                Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
                thisRB.AddForce(movement * accelerationForce);
            }
        }
        else
        {
            thisGO = GameObject.FindGameObjectWithTag("Player");
            thisRB = thisGO.GetComponent<Rigidbody>();
        }

        

        

        /*
        if (upArrow == true)
        {

            thisRB.AddTorque(new Vector3(1, 0,0 ) * maxAccelerationForce);
            //pushedUpArrow = true;
        }
        if (upArrow == false && pushedUpArrow == true)
        {
            if (thisRB.velocity.z > 0)
            {
                thisRB.AddTorque(new Vector3(-1, 0, 0) * maxAccelerationForce / 10);
            }
            else
            {
                thisRB.velocity = new Vector3(0,0,0);
                pushedUpArrow = false;
            }
        }
        
        if (downArrow == true)
        {
            thisRB.AddTorque(new Vector3(-1, 0, 0 ) * maxAccelerationForce);
        }
        if (downArrow == false && pushedDownArrow == true)
        {
            thisRB.AddTorque(new Vector3(1, 0, 0) * maxAccelerationForce);
        }

        if (rightArrow == true)
        {
            thisRB.AddTorque(new Vector3( 0, 0, -1) * maxAccelerationForce);
        }

        if (leftArrow == true)
        {
            thisRB.AddTorque(new Vector3(0, 0, 1) * maxAccelerationForce);
        }
        */
    }

    IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(jumpDelay);
        jumpDone = true;
    }
}
