using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModifier : MonoBehaviour {

    private GameObject playerGO;       

    public Vector3 offset;

    void Start () {
        playerGO = GameObject.FindGameObjectWithTag("Player");

    }

	void Update () {
        if (playerGO != null)
        {
            transform.position = playerGO.transform.position + offset;
        }
        else
        {
            playerGO = GameObject.FindGameObjectWithTag("Player");
        }
	}
}
