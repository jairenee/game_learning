using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    float direction;
    bool isJumping;
    bool isGrounded = true;

    public float moveSpeed = 4.0f;
    public float jumpForce = 40f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private Vector3 thisVelocity = Vector3.zero;
    [Range(0, .3f)] private float movementSmooth = .05f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input
        direction = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump")) {
            isJumping = true;
        }

        //direction = new vector3(input.getaxis("horizontal") * movespeed * time.deltatime,
        //                        isjumping * jumpforce * time.deltatime, 0.0f);
    }

    private void FixedUpdate()
    {
        //float vertical = 0.0f;
        Debug.Log(isJumping);
       
        Vector3 targetVelocity = new Vector2(direction * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref thisVelocity, movementSmooth);

        if (direction > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (direction < 0 && facingRight)
        {
            FlipCharacter();
        }

        if (isGrounded && isJumping)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }

        //if (rb.velocity.y < 0)
        //{
        //    rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        //}
        //else if (rb.velocity.y > 0 && !isJumping)
        //{
        //    rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        //}
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
