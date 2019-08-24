using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBlock : MonoBehaviour
{
    [SerializeField] private float frequency;
    [SerializeField] private float magnitude;

    private float startTime;

    private Vector3 position;

    [SerializeField] 
    private bool isPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isPlaced) {
            position = transform.position;
        }
        startTime = Time.time;
    }

    public void PlaceBlock()
    {
        isPlaced = true;
        position = transform.position;
    }

    void Update()
    {
        var offset = Mathf.Sin(startTime - Time.time * frequency) * magnitude;
        if (isPlaced)
        {
            // If the block has been placed, move it relative to where it was placed
            transform.position = position + transform.up * offset;
        }
        else
        {
            // If the block is being placed, move it relative to where it currently is (the player's mouse)
            transform.position = transform.position + transform.up * offset;
        }
    }
}
