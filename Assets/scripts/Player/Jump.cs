using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private int extraJumps;

    private Rigidbody2D rb;
    private int extrasUsed = 0;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumping = Input.GetButtonDown("Jump");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            animator.SetBool("Jumping", false);
            extrasUsed = 0;
        }

        if (isJumping && (isGrounded || extrasUsed < extraJumps))
        {
            animator.SetBool("Jumping", true);
            rb.velocity = Vector2.up * jumpForce;
            extrasUsed++;
        }

    }
}
