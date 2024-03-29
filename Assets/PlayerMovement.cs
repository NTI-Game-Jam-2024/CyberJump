using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    private float moveInput;
    public bool isGrounded = true;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;
    public bool Active = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Active == true)
        {
            moveInput = Input.GetAxisRaw("Horizontal");


            if (isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
            }


            isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
            new Vector2(0.9f, 0.4f), 0f, groundMask);

            if (jumpValue > 0)
            {
                rb.sharedMaterial = bounceMat;
            }
            else
            {
                rb.sharedMaterial = normalMat;
            }


            if (Input.GetKey(KeyCode.W) && isGrounded && canJump)
            {
                jumpValue += 0.05f;
            }


            if (Input.GetKeyDown(KeyCode.W) && isGrounded && canJump)
            {
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
            }


            if (jumpValue >= 20f && isGrounded)
            {
                float tempx = moveInput * walkSpeed;
                float tempy = jumpValue;
                rb.velocity = new Vector2(tempx, tempy);
                Invoke("ResetJump", 0.2f);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                if (isGrounded)
                {
                    rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                    jumpValue = 0.0f;
                }
                canJump = true;
            }
        }
        
    }


    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }

    

    

}
