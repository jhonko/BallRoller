using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlane : MonoBehaviour {

    public float speedModifier;

    public AudioSource boostPlaneSound;

    private Vector3 ballDirection;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boostPlaneSound.Play();
            GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
            Rigidbody playerRB = playerGO.GetComponent<Rigidbody>();

            ballDirection.z = playerRB.velocity.z;
            ballDirection.x = playerRB.velocity.x;

            playerRB.AddForce(ballDirection * speedModifier, ForceMode.VelocityChange);
        }
    }
}
