using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public bool flashlight;

    private void Awake()
    {
        flashlight = false;
        DontDestroyOnLoad(gameObject);
    }
}
