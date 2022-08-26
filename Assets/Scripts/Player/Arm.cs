using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{

    public void UpdateAngle(Vector3 rot)
    {
        transform.eulerAngles = rot;
    }
}
