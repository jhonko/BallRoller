using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandeller : MonoBehaviour {

    private int levelCount;


    private GameObject levelTimerGO;
    private LevelTimer levelTimer;
    
    private HighScoreHandeller highScoreHandellerGO;

    public int amountOfScenes = 10;

    void Awake()
    {
       
        DontDestroyOnLoad(gameObject);
       
        // highScoreHandellerGO = highScoreHandellerGO.GetComponent<HighScoreHandeller>();
        // highScoreHandellerGO = GameObject.FindObjectOfType(typeof(HighScoreHandeller)) as HighScoreHandeller;
        //  highScoreHandellerGO.SetLevelCounter();
    }

    public void Update()
    {
        if (levelTimerGO != null) {
            levelTimerGO = GameObject.FindGameObjectWithTag("TimerGO");
            levelTimer = levelTimerGO.GetComponent<LevelTimer>();
            levelTimer = GameObject.FindObjectOfType(typeof(LevelTimer)) as LevelTimer;
        }
        //Debug.Log(levelCount);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void StartTestLevel()
    {
        SceneManager.LoadScene("TestScene");
    }



    public void StartLevel01(int gainedLevelCount)
    {

   
            GetHighScoreHandeller();
            levelCount = gainedLevelCount;
            highScoreHandellerGO.SetLevelCounter(levelCount);
            SceneManager.LoadScene("GameScene0."+gainedLevelCount);
            //levelTimer.StartTimer();
        
        /*GetHighScoreHandeller();
        levelCount = 2;
        highScoreHandellerGO.SetLevelCounter(levelCount);
        SceneManager.LoadScene("GameScene0.1");
        levelTimer.StartTimer();*/


    }

   /* public void StartLevel02()
    {
        
        levelCount = 3;
        SceneManager.LoadScene("GameScene0.2");
       // highScoreHandeller.levelCounter = levelCount;
    }*/

    public void FinishedCourse()
    {
        SceneManager.LoadScene("FinishedCourseScene");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void SelectMenu()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        Debug.Log("mag niet jammer joh");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        if (levelCount >= amountOfScenes)
        {
            Debug.Log("wtf");
            levelCount = amountOfScenes;
        }
        else
        {
            Debug.Log("amount of sscenes " + amountOfScenes + "levelcount " + levelCount);
            GetHighScoreHandeller();
            levelCount++;
            highScoreHandellerGO.SetLevelCounter(levelCount);
            //levelTimer.StartTimer();
            //  Debug.Log(levelCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelCount);
        }

        // highScoreHandeller.levelCounter = levelCount;
    }

    public void GetHighScoreHandeller()
    {
        highScoreHandellerGO = GameObject.FindObjectOfType(typeof(HighScoreHandeller)) as HighScoreHandeller;
    }
}
