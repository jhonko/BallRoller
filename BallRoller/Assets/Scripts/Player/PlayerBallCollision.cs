using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallCollision : MonoBehaviour {

   
    public SceneHandeller sceneHandellerScript;

    public PlayerBallSpawner playerBallSpawner;

   


    // Use this for initialization
    void Start () {
        

        // GameObject sceneHandellerGO = GameObject.FindGameObjectWithTag("SceneHandellerGO");
        //sceneHandellerScript = sceneHandellerGO.GetComponent("SceneHandeller") as SceneHandeller;
        // sceneHandellerGO = GameObject.FindObjectOfType(typeof(SceneHandeller)) as SceneHandeller;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            Debug.Log("dood jonge" +  this.transform.position);
            playerBallSpawner.Respawn();
            Destroy(this.gameObject);
            //sceneHandellerScript.RestartScene();
        }
    }
}
