using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int lives;
    public int maxLives;
    public Image[] lifeImages;
    public Image lifePrefab;
    public Sprite fullLife;
    public Sprite emptyLife;

    // Start is called before the first frame update
    void Start()
    {
        Transform canvas = GameObject.Find("PlayerLives").transform;
        lifeImages = new Image[lives];
        for (int i = 0; i < lifeImages.Length; i++)
        {
            lifeImages[i] = Instantiate(lifePrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
            lifeImages[i].transform.SetParent(canvas, false);
            lifeImages[i].transform.Translate(i * 1f, 0, 0);
        }

    }

    void Init(int lives)
    {
        this.lives = lives;
    }

    // Update is called once per frame
    void Update()
    {
        // if(lives > maxLives) {
        //     lives = maxLives;
        // }

        // for (int i = 0; i < hearts.Length; i++)
        // {
        //     if(i < lives) {
        //         hearts[i].sprite = fullHeart;
        //     } else {
        //         hearts[i].sprite = emptyHeart;
        //     }

        //     if (i < maxLives)
        //     {
        //         hearts[i].enabled = true;
        //     }
        //     else
        //     {
        //         hearts[i].enabled = false;
        //     }
        // }
    }
}
