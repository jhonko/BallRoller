using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    public SceneHandeller sceneHandellerScript;
    public LevelTimer levelTimer;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelTimer.StopTimer();
            sceneHandellerScript.FinishedCourse();
        }
    }
}
