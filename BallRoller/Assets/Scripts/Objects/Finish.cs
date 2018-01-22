using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

 
    public SceneHandeller sceneHandellerScript;
    public LevelTimer levelTimer;

    void Start()
    {

       // GameObject sceneHandellerGO = GameObject.FindGameObjectWithTag("SceneHandellerGO");
       // sceneHandellerScript = sceneHandellerGO.GetComponent("SceneHandeller") as SceneHandeller;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelTimer.StopTimer();
            sceneHandellerScript.FinishedCourse();
        }
    }
}
