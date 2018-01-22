using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuHandeller : MonoBehaviour {


    public GameObject inGameMenu;

    public void SwitchMenu()
    {
       
        
     
        //GameObject MenuGO = GameObject.FindGameObjectWithTag("InGameMenu");

        if (inGameMenu.activeSelf == false) {
            inGameMenu.SetActive(true);            
        } else {
            inGameMenu.SetActive(false);
        }
    }
}
