using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource source;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!source.isPlaying) source.Play();
        }
    }
}
