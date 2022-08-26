using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{

    [SerializeField] float speedMult = 1.0f;
    [SerializeField] float jumpForce = 1.0f;
    [SerializeField] GameObject flashlight;

    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer renderer;
    private Animator anim;

    private float speed = 0.0f;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            speed = speedMult;
            renderer.flipX = false;
            anim.SetBool("isWalking", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            speed = -speedMult;
            renderer.flipX = true;
            anim.SetBool("isWalking", true);
        }
        else
        {
            speed = 0.0f;
            anim.SetBool("isWalking", false);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump();
            anim.SetBool("isJumping", true);
        }



        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Jump()
    {
        //check if grounded
        RaycastHit2D[] hits = { };
        
        if(isGrounded)
        {
            Debug.Log("jump");
            rb.AddForce(new Vector2(0, jumpForce));
        }


        

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Tilemap")
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
            Debug.Log("Landed");
        }
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Tilemap")
        {
            isGrounded = false;
        }
    }
}
