using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallSpawner : MonoBehaviour {

    public GameObject ballPrefab;

    void Start () {
        GameObject activeBall = Instantiate(ballPrefab) as GameObject;
        activeBall.SetActive(true);
    }

    public void Respawn()
    {
        GameObject activeBall = Instantiate(ballPrefab) as GameObject;
        activeBall.SetActive(true);
    }
}
