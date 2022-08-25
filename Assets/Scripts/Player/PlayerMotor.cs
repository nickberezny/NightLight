using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    [SerializeField] float speedMult = 1.0f;
    [SerializeField] float jumpForce = 1.0f;
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private float speed = 0.0f;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            speed = speedMult;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            speed = -speedMult;
        }
        else
        {
            speed = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
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
        if(col.transform.tag == "Tilemap")
        {
            isGrounded = true;
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
