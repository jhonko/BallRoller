using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlaneLight : MonoBehaviour
{
    public GameObject[] lightsArray;

    private int lightCounter;
    private int maxLightCounter;

    void Start()
    {
        maxLightCounter = lightsArray.Length;
        StartLights();

        
    }

    void StartLights()
    {
        if (lightCounter >= maxLightCounter)
        {
            lightCounter = 0;
        }
    //    Debug.Log(lightCounter);
        lightsArray[lightCounter].SetActive(true);
        lightCounter++;
        StartCoroutine("WaitForSwitchOff");

    }

    IEnumerator WaitForSwitchOff()
    {
       // Debug.Log("OFF");
        int thisOffCounter;
        thisOffCounter = lightCounter -1;
        StartCoroutine("WaitForSwitchOn");
        yield return new WaitForSeconds(0.4f);
       // Debug.Log(lightsArray[thisOffCounter]);
        lightsArray[thisOffCounter].SetActive(false);
        

    }

    IEnumerator WaitForSwitchOn()
    {
      //  Debug.Log("ON");

        yield return new WaitForSeconds(0.1f);
        StartLights();


    }

}
