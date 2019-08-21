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

	void OnMouseUp() {
		Debug.Log("Blam!");
		Destroy(gameObject);
	}

}
