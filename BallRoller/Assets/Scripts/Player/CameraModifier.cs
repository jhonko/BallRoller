using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModifier : MonoBehaviour {

    private GameObject playerGO;       

    public Vector3 offset;

    // Use this for initialization
    void Start () {
        playerGO = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        if (playerGO != null)
        {
           // Debug.Log(playerGO);
            transform.position = playerGO.transform.position + offset;
        }
        else
        {
            playerGO = GameObject.FindGameObjectWithTag("Player");
        }
	}
}
