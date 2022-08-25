using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    public bool lighted = true;

    [SerializeField] GameObject[] NightLights;
    [SerializeField] GameObject[] DayLights;

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
    }
}
