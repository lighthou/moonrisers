using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableBlock : MonoBehaviour, IBlock
{
    [SerializeField] private float ySpeed;
    [SerializeField] private float xSpeed;
    [SerializeField] private float magnitude;
    private float startTime;
    private Vector3 position;
    private Block block;

    public bool blockPlaced = false;

    public void Start()
    {
        // TODO: Remove this, for debugging purposes only 
        startTime = Time.time;
        position = transform.position;
        block = GetComponent<Block>();
    }

    public void PlaceBlock()
    {
        blockPlaced = true;
        startTime = Time.time;
        position = transform.position;
    }

    public void Update()
    {
        if (blockPlaced)
        {
            var deltaTime = startTime - Time.time;
            var xOffset = Mathf.Sin(deltaTime * xSpeed) * magnitude * deltaTime;
            var yOffset = Mathf.Sin(deltaTime * ySpeed) * magnitude * deltaTime;
            transform.position = position + transform.up * yOffset + transform.right * xOffset;
            block.TakeDamage(1);
        }
    }
}
