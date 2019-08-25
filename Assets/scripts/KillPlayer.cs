using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Destroy");

        if (collision.gameObject.tag == "Player")
        {
            GameMaster.KillPlayer(collision.gameObject.GetComponent<PlayerController>());
        }
    }

}
