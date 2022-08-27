using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{

    Transform player;
    [SerializeField] private Light2D light;
    [SerializeField] private Atenna[] atennas;
    [SerializeField] private Arm arm;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer armRenderer;
    private StateManager stateManager;
    private SFXManager sfx;
    private bool NightTime = true;
    private bool flashlightOn;
   


    private void Awake()
    {
        player = transform.parent.transform;
        stateManager = FindObjectOfType<StateManager>();
        sfx = FindObjectOfType<SFXManager>();

    }

    private void Start()
    {
        
      
        if (stateManager.flashlight)
        {
            flashlightOn = true;
            SetLights();
            foreach (Atenna atenna in atennas)
            {
                atenna.SwitchAttena(false);
                if (anim) anim.SetBool("flashlightOn", true);
                if (armRenderer) armRenderer.enabled = true;
            }
        }
        else
        {
            flashlightOn = false;
            light.enabled = false;
            foreach (Atenna atenna in atennas)
            {
                atenna.SwitchAttena(true);
                if (anim) anim.SetBool("flashlightOn", false);
                if (armRenderer) armRenderer.enabled = false;
            }
        }
        
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rot = new Vector3(0, 0, Mathf.Atan2(mousePos.y - player.position.y, mousePos.x - player.position.x));
        //Debug.Log(player.position.x + ',' + Input.mousePosition.x);
        transform.eulerAngles = rot*180.0f/(Mathf.PI);
        if(arm) arm.UpdateAngle(rot * 180.0f / (Mathf.PI));

        if (Input.GetMouseButtonDown(0))
        {
            flashlightOn = !flashlightOn;
            stateManager.flashlight = flashlightOn;

            if (flashlightOn)
            {
                sfx.PlayAudio("Click");
                SetLights();
                foreach(Atenna atenna in atennas)
                {
                    atenna.SwitchAttena(false);
                    if(anim) anim.SetBool("flashlightOn", true);
                    if (armRenderer) armRenderer.enabled = true;
                }
            }
            else
            {
                light.enabled = false;
                foreach (Atenna atenna in atennas)
                {
                    atenna.SwitchAttena(true);
                    if (anim) anim.SetBool("flashlightOn", false);
                    if (armRenderer) armRenderer.enabled = false;
                }
            }
        }
    }

    public void ChangeDayTime(bool dayTime)
    {
        NightTime = dayTime;
        Debug.Log(transform.name + ':' + dayTime);
        if (flashlightOn) SetLights();
    }

    private void SetLights()
    {
        light.enabled = NightTime;
    }
}
