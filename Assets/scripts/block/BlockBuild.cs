using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuild : MonoBehaviour {
	public BlockFactory blockFactory;
	private bool currrentlyPlacing;

	private GameObject ghost;
	private SpriteRenderer ghostSpriteRenderer;
	private BoxCollider2D ghostCollider;

	private Color canPlaceColor;
	private Color cantPlaceColor;

    private Vector2 dimensions;

    // Use this for initialization
    void Start () {
		// TODO: Change this to use a scriptable object
		canPlaceColor = new Color(1, 0, 1, 0.5f); // magenta
		cantPlaceColor = new Color(1, 0, 0, 0.5f); // red
		
		GetNewGhost();
	}

	void GetNewGhost() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		ghost = blockFactory.GetNextBlock(mousePos);

		ghostSpriteRenderer = ghost.GetComponent<SpriteRenderer>();
		
		ghostCollider = ghost.GetComponent<BoxCollider2D>();		
		float width = ghostCollider.bounds.size.x;
		float height = ghostCollider.bounds.size.y;
		dimensions = new Vector2(width, height);
		ghostCollider.enabled = false;
	}
	
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
		ghost.transform.position = mousePos2D;

		RaycastHit2D boxCast = Physics2D.BoxCast(mousePos, dimensions, 0, Vector2.zero);
		bool canPlace = boxCast.collider == null;

		if (canPlace) {
			ghostSpriteRenderer.color = canPlaceColor;
		} else {
			ghostSpriteRenderer.color = cantPlaceColor;
		}

		if (!currrentlyPlacing && Input.GetMouseButtonDown(0)) {
			// store dimensions of ghost for collision calculation
			currrentlyPlacing = true;
		}

		if (currrentlyPlacing && Input.GetMouseButtonUp(0) && canPlace) {
			ghost.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			ghostSpriteRenderer.color = Color.black;
			currrentlyPlacing = false;
			ghostCollider.enabled = true;
			GetNewGhost();
		}
	}
}
