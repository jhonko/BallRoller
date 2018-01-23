using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighScoreHandeller : MonoBehaviour {

    public float levelCounter;
    public float levelTime;

    public int levelMaxCoins;
    public int levelPickedUpCoins;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetLevelCounter(float counter)
    {
        levelCounter = counter;
    }

    public void SetLevelTime(float time)
    {
        levelTime = time;
    }

    public void SetLevelCoins(int maxCoins, int pickedUpCoins)
    {
        if (pickedUpCoins == 0)
        {
            levelMaxCoins = maxCoins;
            levelPickedUpCoins = 0;
        }
        levelMaxCoins = maxCoins;
        levelPickedUpCoins += pickedUpCoins;
    }

    public float GetLevelCounter()
    {
        float counter = levelCounter;
        return counter;
    }

    public float GetLevelTimer()
    {
        float time = levelTime;
        return time;
    }

    public int GetMaxLevelCoins()
    {
        int maxAmountCoins = levelMaxCoins;
        return maxAmountCoins;
    }

    public int GetPickedUpLevelCoins()
    {
        int pickedUpAmountCoins = levelPickedUpCoins-1;
        return pickedUpAmountCoins;
    }
}
