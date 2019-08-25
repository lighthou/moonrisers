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
        // Transform canvas = GameObject.Find("PlayerLives").transform;
        // lifeImages = new Image[lives];
        // for (int i = 0; i < lifeImages.Length; i++)
        // {
        //     if (i == 0)
        //     {
        //         lifeImages[i] = Instantiate(lifePrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        //         lifeImages[i].transform.SetParent(canvas, false);
        //         lifeImages[i].transform.Translate(-1, 0, 0);
        //     }
        //     else if (i == 1)
        //     {
        //         lifeImages[i] = Instantiate(lifePrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        //         lifeImages[i].transform.SetParent(canvas, false);
        //     }
        //     else
        //     {
        //         lifeImages[i] = Instantiate(lifePrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        //         lifeImages[i].transform.SetParent(canvas, false);
        //         lifeImages[i].transform.Translate(1, 0, 0);
        //     }
        // }
    }

    public void Init(int lives)
    {
        this.lives = lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives > maxLives)
        {
            lives = maxLives;
        }

        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < lives)
            {
                lifeImages[i].sprite = fullLife;
            }
            else
            {
                lifeImages[i].sprite = emptyLife;
            }
        }
    }

    private bool isEven(int number)
    {
        return number % 2 == 0 ? true : false;
    }
}
