using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onCollisionEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            Debug.Log("You WIN!");
        }
    }
}
