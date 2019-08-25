using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    [SerializeField] public static Transform playerTransform { get; private set; }
    public CameraController camera;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public Transform gameOverPrefab;

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

        GameObject.Find("GameOver").GetComponent<Image>().enabled = false;

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
        Debug.Log(lives);
        if (lives > 0)
        {
            gm.RespawnPlayer();
            playerTransform.GetComponent<Lives>().Init(lives - 1);

        }
        else
        {
            // Transform hud = GameObject.Find("HUD").transform;
            // Transform gameover = Instantiate(gameOverPrefab, Vector3.zero, Quaternion.Euler(0,0,0));
            // gameover.SetParent(hud, false);
            // TODO display game over;
            GameObject.Find("GameOver").GetComponent<Image>().enabled = true;
        }
    }
}
