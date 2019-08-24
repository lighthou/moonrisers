using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    // void OnTriggerEnter2D(Collider2D collider) {
    //     Debug.Log(collider);
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision);
            GameMaster.KillPlayer(collision.gameObject.GetComponent<PlayerController>());
        }
    }

}
