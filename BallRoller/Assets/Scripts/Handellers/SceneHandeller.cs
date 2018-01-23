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
    }

    public void Update()
    {
        if (levelTimerGO != null) {
            levelTimerGO = GameObject.FindGameObjectWithTag("TimerGO");
            levelTimer = levelTimerGO.GetComponent<LevelTimer>();
            levelTimer = GameObject.FindObjectOfType(typeof(LevelTimer)) as LevelTimer;
        }
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
    }

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

    public void NextScene()
    {
        if (levelCount >= amountOfScenes)
        {
            levelCount = amountOfScenes;
        }
        else
        {
            GetHighScoreHandeller();
            levelCount++;
            highScoreHandellerGO.SetLevelCounter(levelCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelCount);
        }
    }

    public void GetHighScoreHandeller()
    {
        highScoreHandellerGO = GameObject.FindObjectOfType(typeof(HighScoreHandeller)) as HighScoreHandeller;
    }
}
