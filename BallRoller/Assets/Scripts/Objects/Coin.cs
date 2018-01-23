using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public float rotateSpeed;

    public AudioSource coinSound;

    private HighScoreHandeller highScoreHandellerGO;

    public int thisLevelMaxCoins;

    public bool newGame = true;

    void Start () {
        SetCoinScore();
	}
	
	void Update () {
        this.transform.Rotate(Vector3.up * rotateSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SetCoinScore();
            coinSound.Play();
            Destroy(this.gameObject, 0.1f);
        }
    }

    void SetCoinScore()
    {
        if (newGame == true)
        {
       
                highScoreHandellerGO = GameObject.FindObjectOfType(typeof(HighScoreHandeller)) as HighScoreHandeller;
                highScoreHandellerGO.SetLevelCoins(thisLevelMaxCoins, 0);           
                newGame = false;
        }
        highScoreHandellerGO = GameObject.FindObjectOfType(typeof(HighScoreHandeller)) as HighScoreHandeller;
        highScoreHandellerGO.SetLevelCoins(thisLevelMaxCoins, 1);
    }
}
