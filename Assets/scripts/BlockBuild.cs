using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuild : MonoBehaviour {
	public GameObject toPlaceDynamic;
	public GameObject toPlaceFixed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
			
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null) {
				Debug.Log("Hit Something!" + hit.collider);
				Destroy(hit.collider.transform.parent);
			} else {
				GameObject placed;
				if (Input.GetMouseButton(0)) {
					placed = Instantiate(toPlaceDynamic);
				} else {
					placed = Instantiate(toPlaceFixed);
				}
							
				Vector3 centerLocation = new Vector3(mousePos.x, mousePos.y, 0);
				Collider2D placedCollider = placed.GetComponent<Collider2D>();
				float width = placedCollider.bounds.size.x;
				float height = placedCollider.bounds.size.y;
				Vector2 dimensions = new Vector2(width, height);

				RaycastHit2D boxCast = Physics2D.BoxCast(centerLocation, dimensions, 0, Vector2.zero);
				if (boxCast.collider == null) {
					placed.transform.position = centerLocation;
				} else {
					Destroy(placed);
				}
			}
		}
	}

	void PlaceBlock(Vector3 whereToPlace, GameObject toPlace) {
		
	}
}
