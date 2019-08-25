﻿using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
    public BlockFactory blockFactory;
    private bool currrentlyPlacing;

    private GameObject ghost;
    private BoxCollider2D ghostCollider;

    private Color canPlaceColor;
    private Color cantPlaceColor;

    private Vector2 dimensions;

    // Use this for initialization
    void Start()
    {
        // TODO: Change this to use a scriptable object
        canPlaceColor = new Color(1, 0, 1, 0.5f); // magenta
        cantPlaceColor = new Color(1, 0, 0, 0.5f); // red

        GetNewGhost();
    }

    void GetNewGhost()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ghost = blockFactory.GetNextBlock(mousePos);

        ghostCollider = ghost.GetComponent<BoxCollider2D>();
        float width = ghostCollider.bounds.size.x;
        float height = ghostCollider.bounds.size.y;
        dimensions = new Vector2(width, height);
        ghostCollider.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        var canPlaceBlock = MoveBlock();

        var colorToApply = canPlaceBlock ? canPlaceColor : cantPlaceColor;
        ApplyColor(colorToApply);

        if (!currrentlyPlacing && Input.GetMouseButtonDown(0))
        {
            currrentlyPlacing = true;
        }

        if (currrentlyPlacing && Input.GetMouseButtonUp(0) && canPlaceBlock)
        {
            PlaceBlock();
            GetNewGhost();
        }
    }

    /* Returns whether the block can be placed */
    bool MoveBlock()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        ghost.transform.position = mousePos2D;
        RaycastHit2D boxCast = Physics2D.BoxCast(mousePos, dimensions, 0, Vector2.zero);
        return boxCast.collider == null;
    }

    void PlaceBlock()
    {
        var rigidbody = ghost.GetComponent<Rigidbody2D>();
        if (rigidbody != null)
        {
            rigidbody.velocity = Vector2.zero;
        }

        var components = ghost.GetComponents<MonoBehaviour>();
        foreach (var component in components )
        {
            if (component is IBlock) {
                ((IBlock) component).PlaceBlock();
            }
        }

        // Reset the color back to normal
        ApplyColor(Color.white);
        currrentlyPlacing = false;
        ghostCollider.enabled = true;
    }

    void ApplyColor(Color color)
    {
        var sprites = ghost.GetComponentsInChildren<SpriteRenderer>();
        foreach (var sprite in sprites)
        {
            sprite.color = color;
        }
    }
}