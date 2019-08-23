using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuild : MonoBehaviour {
	public GameObject toPlaceDynamic;
	public GameObject toPlaceFixed;
	private GameObject dynamicGhost;
	private GameObject fixedGhost;
	private Color ghostColor;
	private Color invisible;

	private GameObject placing;
	private bool currrentlyPlacing;
	private Vector2 dimensions; // dimensions of box being placed


	private GameObject ghost;
	private SpriteRenderer ghostSpriteRenderer;
	private BoxCollider2D ghostCollider;

	private Color canPlaceColor;
	private Color cantPlaceColor;

	// Use this for initialization
	void Start () {
		canPlaceColor = new Color(1, 0, 1, 0.5f); // magenta
		cantPlaceColor = new Color(1, 0, 0, 0.5f); // red
		GetNewGhost();
	}

	void GetNewGhost() {
		// if (ghost != null) {
		// 	Destroy(ghost);
		// }
		ghost = Instantiate(toPlaceDynamic);
		ghostSpriteRenderer = ghost.GetComponent<SpriteRenderer>();
		ghostSpriteRenderer.color = Color.clear; // otherwise it will flicker in spawn location beore heading to mouse
		
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
