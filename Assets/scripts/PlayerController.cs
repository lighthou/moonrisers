using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private float speed;
	private Rigidbody2D rb2d;
	private bool jumping = false;
	private bool hasLanded = true;
	private bool facingLeft = true;
	private SpriteRenderer spriteRenderer;
	private int floorLayer = 8;

	// Use this for initialization
	void Start () {
		speed = 0.1f;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	void flip() {
		spriteRenderer.flipX = !spriteRenderer.flipX;
		facingLeft = !facingLeft;
	}
	
	// Update is called once per frame
	void Update () {
		// Move left and right
		float translation = Input.GetAxis("Horizontal") * speed;
		transform.Translate(translation, 0, 0);

		// Change appearance based on direction travelled
		if ((facingLeft && translation > 0) || (!facingLeft && translation < 0)) {
			flip();
		}

		// Jump
		if (Input.GetAxis("Jump") == 1f && !jumping && hasLanded) {
			rb2d.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
			jumping = true;
			hasLanded = false;
		} else if (Input.GetAxis("Jump") == 0f) {
			jumping = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		int col_layer = col.gameObject.layer;
		if (col_layer == floorLayer) {
			hasLanded = true;
		}
	}
}
