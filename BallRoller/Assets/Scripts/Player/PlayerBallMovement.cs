using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallMovement : MonoBehaviour {

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
    }

    IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(jumpDelay);
        jumpDone = true;
    }
}
