using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    public int lives = 3;

    private Rigidbody2D rb;
    private bool facingLeft = true;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        facingLeft = !facingLeft;
    }

    // Update is called once per frame
    void Update()
    {

        Move(Input.GetAxis("Horizontal"));
    }

    void Move(float moveInput)
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.x);

        // Change appearance based on direction travelled
        if (((facingLeft && moveInput > 0) || (!facingLeft && moveInput < 0)))
        {
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        switch (trigger.gameObject.tag)
        {
            case "Moon":
                Debug.Log("WINNER!");
                break;
            default: break;
        }
    }


    public void removeLives(int num)
    {
        lives -= num;
    }

}
