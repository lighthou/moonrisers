using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        }
    }

    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Add spawn particles");
    }

    public static void KillPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
        gm.RespawnPlayer();
    }
}
