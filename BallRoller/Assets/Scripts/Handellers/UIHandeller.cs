using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandeller : MonoBehaviour {

    public bool finishedLevelScene = false;
    public bool selectLevelScene = false;
    public bool inGameScene = false;

    public Text lastLevelText;
    private float lastLevel;

    public Text lastLevelTimeText;
    private float lastLevelTime;

    public Text lastLevelCoinScoreText;
    private int lastLevelCoinScore;
    private int lastLevelCoinAmount;


    public Text activeTimerText;
    private float activeTimer;

    private HighScoreHandeller highScoreHandellerGO;

    private LevelTimer levelTimerGO;

    void Start () {
        if (finishedLevelScene == true)
        {
            SetLastLevelText();
            SetLastLevelTimeText();
            SetLastLevelCoinScore();
        }
        if (selectLevelScene == true)
        {

        }
        if (inGameScene == true)
        {

        }
    }
	
	void FixedUpdate () {
        if (inGameScene == true)
        {
            SetCurrentTime();
        }
    }

    public void SetLastLevelText()
    {
        GetLastLevel();
        lastLevelText.text = ("Level: " +(float)lastLevel).ToString(); 
    }

    public void SetLastLevelTimeText()
    {
        GetLastLevelTime();
        lastLevelTimeText.text = ("Final Time: "+(float)lastLevelTime).ToString(); 
    }

    public void SetLastLevelCoinScore()
    {
        GetLastLevelCoinScore();
        lastLevelCoinScoreText.text = ("Coin Score: " + (int)lastLevelCoinScore).ToString() +"/"+ ((int)lastLevelCoinAmount).ToString(); 
    }

    public void SetCurrentTime()
    {
        GetCurrentTime();
        activeTimerText.text = ("Time: "+(float)activeTimer).ToString();
    }

    public void GetCurrentTime()
    {
        GetLevelTimer();
        activeTimer = levelTimerGO.GetActiveLevelTimer();
        
    }

    public void GetLastLevel()
    {
        GetHighScoreHandeller();
        lastLevel = highScoreHandellerGO.GetLevelCounter();
    }

    public void GetLastLevelTime()
    {
        GetHighScoreHandeller();
        lastLevelTime = highScoreHandellerGO.GetLevelTimer();

    }

    public void GetLastLevelCoinScore()
    {
        GetHighScoreHandeller();
        lastLevelCoinScore = highScoreHandellerGO.GetPickedUpLevelCoins();
        lastLevelCoinAmount = highScoreHandellerGO.GetMaxLevelCoins();
    }

    public void GetHighScoreHandeller()
    {
        highScoreHandellerGO = GameObject.FindObjectOfType(typeof(HighScoreHandeller)) as HighScoreHandeller;
    }

    public void GetLevelTimer()
    {
        levelTimerGO = GameObject.FindObjectOfType(typeof(LevelTimer)) as LevelTimer;
    }


}
