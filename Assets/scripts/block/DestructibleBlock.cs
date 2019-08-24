using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBlock : MonoBehaviour {

	public int overlaps;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(1)) {
			Debug.Log("Blam!");
			Destroy(gameObject);
		}
	}

}
