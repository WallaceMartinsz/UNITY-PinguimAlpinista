using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] int speed = 5;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    public bool isGrounded;

    public Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMoviment();
        Jump();
    }


    void PlayerMoviment()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        animator.SetBool("taAndando", true);

        Vector3 scale = transform.localScale;
        if (moveInput < 0)
        {
            if (scale.x > 0)
            {
                scale.x = -scale.x;
                transform.localScale = scale;
            }
        }
        else if (moveInput > 0)
        {
            if (scale.x < 0)
            {
                scale.x = -scale.x;
                transform.localScale = scale;
            }
        }

        if (rb2d.velocity.x == 0 && isGrounded)
        {
            animator.SetBool("taAndando", false);
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            animator.SetBool("taPulando", true);
        }
        animator.SetBool("taPulando", !isGrounded);
    }

}
