using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public float dropRate;
    public float dropIncreaseRate;

    public GameObject bomb;

    private float lastDropped;

    private float startTime;

    private float nextDropTime;


    void Start()
    {
        lastDropped = Time.time;
        startTime = Time.time;
        CalculateNextDropTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextDropTime <= Time.time)
        {
            DropBomb();
            lastDropped = Time.time;
            CalculateNextDropTime();
        }
    }

    void DropBomb()
    {
        Debug.Log("Dropping next bomb!");
        Vector2 position = new Vector2(Random.Range(-5f, 5f), Camera.main.transform.position.y + 4);
        Instantiate(bomb, position, Quaternion.identity);
    }

    void CalculateNextDropTime()
    {
        var deltaTime = Time.time - startTime;

        var modifier = Mathf.Clamp(dropRate - deltaTime * dropIncreaseRate, dropRate / 4, dropRate);
        nextDropTime = lastDropped + modifier;
    }
}
