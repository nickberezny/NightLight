using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    [SerializeField] LightManager lightManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Switch")
        {
            lightManager.ChangeLighting(!lightManager.lighted);
        }
    }
}
