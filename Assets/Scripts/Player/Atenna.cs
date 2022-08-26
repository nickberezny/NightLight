using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Atenna : MonoBehaviour
{
    private Light2D attenaLight;

    private void Awake()
    {
        attenaLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    public void SwitchAttena(bool enable)
    {
        attenaLight.enabled = enable;
    }
}
