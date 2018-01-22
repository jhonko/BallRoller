using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour {

    //public float startTime;
    private float endTime;

    private HighScoreHandeller highScoreHandellerGO;

    public HighScoreHandeller highScoreHandeller;

    private float sceneTime;

    private float activeTime;


    public  void Awake()
    {
        sceneTime = Time.time;
        Debug.Log(sceneTime);
        StartTimer();

        // DontDestroyOnLoad(transform.gameObject);
        // Debug.Log("timergestart joh" + startTime);
        // highScoreHandellerGO = GameObject.FindObjectOfType(typeof(HighScoreHandeller)) as HighScoreHandeller;
    }

   public void FixedUpdate() {

    }

    public void StartTimer()
    {

      //  Debug.Log("timergestart joh" + startTime);
      //  startTime = Time.time - sceneTime;
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
        // Debug.Log(startTime);
        //Debug.Log(Time.time);
        //float time = Time.time - startTime;
        return activeTime;
    }

}
