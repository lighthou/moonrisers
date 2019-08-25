using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public int score { get; set; }
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int newHeight = Mathf.FloorToInt(GameMaster.playerTransform.position.y);
        if (newHeight > score)
        {
            score = newHeight;
            scoreText.text = score.ToString();
        }
    }
}
