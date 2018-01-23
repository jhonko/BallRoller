using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour {

    private float endTime;
    private float sceneTime;
    private float activeTime;

    private HighScoreHandeller highScoreHandellerGO;

    public  void Awake()
    {
        sceneTime = Time.time;
    }

    public void StopTimer()
    {   
        highScoreHandellerGO = GameObject.FindObjectOfType(typeof(HighScoreHandeller)) as HighScoreHandeller;
        endTime = Time.time - sceneTime;
        highScoreHandellerGO.SetLevelTime(endTime);
    }

    public float GetActiveLevelTimer()
    {
        activeTime = Time.time - sceneTime;
        return activeTime;
    }
}
