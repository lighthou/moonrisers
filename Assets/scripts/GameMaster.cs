using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    [SerializeField] public static Transform playerTransform { get; private set; }
    public CameraController camera;
    public Transform playerPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        }

        if (playerTransform == null)
        {
            playerTransform = GameObject.Find("Player").transform;
        }

        camera.Init(() => playerTransform.position);
    }

    public void RespawnPlayer()
    {
        playerTransform = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        camera.SetCameraFollowPositionFunc(() => playerTransform.position);
        Debug.Log("Add spawn particles");
    }

    public static void KillPlayer(PlayerController player)
    {
        int lives = player.GetComponent<Lives>().lives;
        Destroy(player.GetComponent<BlockBuilder>().ghost);
        Destroy(player.gameObject);
        if (player.GetComponent<Lives>().lives > 0)
        {
            gm.RespawnPlayer();
            playerTransform.GetComponent<Lives>().lives = lives - 1;

        }
        else
        {
            // TODO display game over;
        }
    }
}
