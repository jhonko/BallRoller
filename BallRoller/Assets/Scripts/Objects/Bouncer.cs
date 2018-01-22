using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour {

    private Vector3 newDirection;
    public float speedModifier;

    public AudioSource bounceSound;

    public GameObject bouncerLight;

    private float bouncerLightTimer;

    void Update()
    {
        if (bouncerLightTimer <= 0)
        {
            TurnOffLight();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bounceSound.Play();
            
            bouncerLight.SetActive(true);          
            StartCoroutine("CountBounces");

            GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
            Rigidbody playerRB = playerGO.GetComponent<Rigidbody>();

            newDirection.z = -playerRB.velocity.z;
            newDirection.x = -playerRB.velocity.x;

          //  Debug.Log(playerRB.velocity + "player velocity");
           // Debug.Log(newDirection + "new direction");
            playerRB.AddForce(newDirection * speedModifier, ForceMode.VelocityChange);

        }
    }

    void TurnOffLight()
    {
        bouncerLight.SetActive(false);
    }

    IEnumerator CountBounces()
    {
        bouncerLightTimer++;
        yield return new WaitForSeconds(2f);
        bouncerLightTimer--;
    }
}
