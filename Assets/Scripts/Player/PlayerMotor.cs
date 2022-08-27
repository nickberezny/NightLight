using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{

    [SerializeField] float speedMult = 1.0f;
    [SerializeField] float jumpForce = 1.0f;
    [SerializeField] GameObject flashlight;

    public bool disable = false; 

    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer renderer;
    private Animator anim;
    private SFXManager sfx;
    

    private float speed = 0.0f;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        sfx = FindObjectOfType<SFXManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!disable)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Jump();
                anim.SetBool("isJumping", true);
            }

            if (Input.GetKey(KeyCode.D))
            {
                speed = speedMult;
                renderer.flipX = false;
                anim.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.A))
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

            

            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
       
    }

    void Jump()
    {
        //check if grounded
        RaycastHit2D[] hits = new RaycastHit2D[3];

        coll.Cast(Vector2.down, hits, 0.05f);

        if(hits[0].transform.tag == "Tilemap")
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            rb.AddForce(new Vector2(0, jumpForce));
            sfx.PlayAudio("Jump");
        }
        else
        {
            coll.Cast(new Vector2(-rb.velocity.x, -1.0f), hits, 0.05f);
            if (hits[0].transform.tag == "Tilemap")
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                rb.AddForce(new Vector2(0, jumpForce));
                sfx.PlayAudio("Jump");
            }
        }

        /*
        if (rb.velocity.y < 0.01f)
        {
            
            
        }
        */



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
