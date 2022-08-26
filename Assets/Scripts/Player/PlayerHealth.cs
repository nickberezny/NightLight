using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ghost")
        {
            //play sound ...
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
