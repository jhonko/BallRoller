using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlane : MonoBehaviour {

    public AudioSource fallPlaneSound;

    public GameObject fallPlaneLight;
    public GameObject fallPlane;

    public float delay;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fallPlaneLight.SetActive(true);
            StartCoroutine("WaitForDestroy");

        }
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(delay);
        fallPlaneSound.Play();
        fallPlane.SetActive(false);
        StartCoroutine("WaitForActivate");
      
        // Destroy(this.gameObject);
    }

    IEnumerator WaitForActivate()
    {
        yield return new WaitForSeconds(delay);
        fallPlane.SetActive(true);
        // Destroy(this.gameObject);
    }
}
