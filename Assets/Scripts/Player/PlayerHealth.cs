using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private SpriteRenderer deathText;
    [SerializeField] private Sprite boo, ahh;
    private SFXManager sfx;
    private PlayerMotor motor;
    private Rigidbody2D rb;



    private void Awake()
    {
        sfx = FindObjectOfType<SFXManager>();
        motor = GetComponent<PlayerMotor>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ghost")
        {
            motor.disable = true;
            sfx.PlayAudio("Death");
            rb.velocity = new Vector2(0.0f, 0.0f);
            rb.AddForce(new Vector2(0.0f, 100.0f));
            deathText.sprite = boo;
            deathText.enabled = true;
            StartCoroutine(WaitToDie(1.5f));
        }
        else if (collision.tag == "Death")
        {
            motor.disable = true;
            sfx.PlayAudio("Death");
            rb.inertia = 100000f;
            deathText.sprite = ahh;
            deathText.enabled = true;
            StartCoroutine(WaitToDie(0.75f));
        }
    }

    IEnumerator WaitToDie(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
