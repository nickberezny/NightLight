using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    public bool lighted = true;

    [SerializeField] GameObject[] NightLights;
    [SerializeField] GameObject[] DayLights;
    [SerializeField] Flashlight NightFlashlight;
    [SerializeField] Flashlight DayFlashlight;

    private void Start()
    {
        ChangeLighting(false);
    }

    public void ChangeLighting(bool lit)
    {
        lighted = lit; 


        foreach(GameObject light in NightLights)
        {
            light.SetActive(lit);
        }

        foreach (GameObject light in DayLights)
        {
            light.SetActive(!lit);
        }

        NightFlashlight.ChangeDayTime(lit);
        DayFlashlight.ChangeDayTime(!lit);
    }
}
