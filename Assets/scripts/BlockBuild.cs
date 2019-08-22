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


	// Use this for initialization
	void Start () {
		placing = null;

		invisible = new Color(0, 0, 0, 0);
		ghostColor = Color.clear;

		dynamicGhost = Instantiate(toPlaceDynamic);
		
		dynamicGhost.GetComponent<BoxCollider2D>().isTrigger = true;
		dynamicGhost.GetComponent<SpriteRenderer>().color = invisible;
		Debug.Log(dynamicGhost.GetComponent<SpriteRenderer>().color);

		fixedGhost = Instantiate(toPlaceFixed);
		fixedGhost.GetComponent<BoxCollider2D>().isTrigger = true;
		fixedGhost.GetComponent<SpriteRenderer>().color = invisible;
	}
	
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

		if (!currrentlyPlacing && Input.GetMouseButtonDown(0)) {
			// make ghost
			placing = Instantiate(toPlaceDynamic);
			placing.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 0.5f); // magenta, in theory
			placing.GetComponent<BoxCollider2D>().isTrigger = true;

			Collider2D placedCollider = placing.GetComponent<Collider2D>();
			float width = placedCollider.bounds.size.x;
			float height = placedCollider.bounds.size.y;
			Debug.Log(width + ", " + height);
			dimensions = new Vector2(width, height);
			placing.GetComponent<BoxCollider2D>().enabled = false;
			currrentlyPlacing = true;
		}

		if (currrentlyPlacing && Input.GetMouseButton(0)) {
			// drag around ghost
			placing.transform.position = mousePos2D;
		}

		if (currrentlyPlacing && Input.GetMouseButtonUp(0)) {
			// Check if colliding with anything
			Vector3 centerLocation = new Vector3(mousePos.x, mousePos.y, 0);
			RaycastHit2D boxCast = Physics2D.BoxCast(centerLocation, dimensions, 0, Vector2.zero);

			if (boxCast.collider == null) {
				// Not colliding, place object
				placing.GetComponent<BoxCollider2D>().isTrigger = false;
				placing.GetComponent<BoxCollider2D>().enabled = true;
				placing.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
				placing.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			} else {
				// Abort mission
				Destroy(placing);
			}
			currrentlyPlacing = false;
		}
	}

	void PlaceBlock(Vector3 whereToPlace, GameObject toPlace) {
		
	}
}
