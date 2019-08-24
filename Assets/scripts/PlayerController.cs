using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb2d;
    private bool jumping = false;
    private bool hasLanded = true;
    private bool facingLeft = true;
    private SpriteRenderer spriteRenderer;
    private int floorLayer = 8;
    private int deathLayer = 9;
    private Animator animator;
    private bool dead;

    // Use this for initialization
    void Start()
    {
        dead = false;
        speed = 0.1f;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    void flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        facingLeft = !facingLeft;
    }

    // Update is called once per frame
    void Update()
    {
        // Move left and right
        float translation = Input.GetAxis("Horizontal") * speed;
        walk(translation);

        // Change appearance based on direction travelled
        if (((facingLeft && translation > 0) || (!facingLeft && translation < 0)) && !dead)
        {
            flip();
        }

        // Jump
        if (Input.GetAxis("Jump") == 1f && !jumping && hasLanded && !dead)
        {
            jump();
        }
        else if (Input.GetAxis("Jump") == 0f)
        {
            jumping = false;
        }
    }

    void jump()
    {
        if (dead)
        {
            return;
        }
        rb2d.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
        jumping = true;
        hasLanded = false;
    }

    void walk(float translation)
    {
        // translation: walk power. Negative for left-walking
        if (dead)
        {
            return;
        }
        transform.Translate(translation, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        int col_layer = col.gameObject.layer;
        if (col_layer == floorLayer)
        {
            hasLanded = true;
        }
        else if (col_layer == deathLayer)
        {
            Debug.Log("DEAD!");
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        switch (trig.gameObject.tag)
        {
            case "Moon":
                Debug.Log("WINNER!");
                break;
            default: break;
        }

        if (trig.gameObject.layer == deathLayer)
        {
            die();
        }
    }


    void die()
    {
        Debug.Log("" + gameObject + " Died!");
        animator.SetBool("Dead", true);
        dead = true;
        // Destroy(gameObject);
    }
}
