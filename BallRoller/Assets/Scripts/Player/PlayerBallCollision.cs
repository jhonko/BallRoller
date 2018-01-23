using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallCollision : MonoBehaviour {

   
    public SceneHandeller sceneHandellerScript;

    public PlayerBallSpawner playerBallSpawner;

	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            Debug.Log("dood jonge" +  this.transform.position);
            playerBallSpawner.Respawn();
            Destroy(this.gameObject);
        }
    }
}
