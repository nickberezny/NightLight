using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{

    [SerializeField] LightManager lightManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Switch")
        {
            lightManager.ChangeLighting(!lightManager.lighted);
            collision.GetComponent<SwitchButton>().PressButton();
        }
        else if(collision.tag =="Door")
        {
            //open next level
            string sceneName = SceneManager.GetActiveScene().name;
            int levelNum = int.Parse(sceneName.Remove(0, 5)) + 1;
            SceneManager.LoadScene("Level" +  levelNum.ToString());
        }
    }
}
