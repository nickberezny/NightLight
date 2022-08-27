using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    [SerializeField] AudioClip jump, click, death, win, lightSwitch;
    private AudioSource source;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
    }

    public void PlayAudio(string soundToPlay)
    {
        switch(soundToPlay)
        {
            case "Jump":
                source.clip = jump;
                source.Play();
                break;
            case "Click":
                source.clip = click;
                source.Play();
                break;
            case "Death":
                source.clip = death;
                source.Play();
                break;
            case "Win":
                source.clip = win;
                source.Play();
                break;
            case "Switch":
                source.clip = lightSwitch;
                source.Play();
                break;
        }
    }
}
