using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
    public BlockFactory blockFactory;
    private bool currrentlyPlacing;

    public GameObject ghost { get; private set; }
    private BoxCollider2D ghostCollider;

    private Color canPlaceColor;
    private Color cantPlaceColor;
    private Color mouseOverColor;

    private Vector2 dimensions;

    // Use this for initialization
    void Start()
    {
        // TODO: Change this to use a scriptable object
        canPlaceColor = new Color(1, 0, 1, 0.5f); // magenta
        cantPlaceColor = new Color(1, 0, 0, 0.5f); // red
        mouseOverColor = new Color(1, 1, 1, 0.1f); // opaic

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
        var mousePosition = MoveBlock();
        Color colorToApply;
        switch (mousePosition)
        {
            case MousePosition.clear:
                colorToApply = canPlaceColor;
                break;
            case MousePosition.colliding:
                colorToApply = cantPlaceColor;
                break;
            default:
                colorToApply = mouseOverColor;
                break;
        }

        ApplyColor(colorToApply);

        if (!currrentlyPlacing && Input.GetMouseButtonDown(0))
        {
            currrentlyPlacing = true;
        }

        if (currrentlyPlacing && Input.GetMouseButtonUp(0) && mousePosition == MousePosition.clear)
        {
            PlaceBlock();
            GetNewGhost();
        }
    }

    /* Returns whether the block can be placed */
    MousePosition MoveBlock()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        ghost.transform.position = mousePos2D;
        RaycastHit2D boxCast = Physics2D.BoxCast(mousePos, dimensions, 0, Vector2.zero);
        if (boxCast.collider == null)
        {
            return MousePosition.clear;
        }

        RaycastHit2D mouseCast = Physics2D.Raycast(mousePos, Vector2.zero, 0);
        return mouseCast.collider == null ? MousePosition.colliding : MousePosition.onBlock;
    }

    void PlaceBlock()
    {
        var rigidbody = ghost.GetComponent<Rigidbody2D>();
        if (rigidbody != null)
        {
            rigidbody.velocity = Vector2.zero;
        }

        var components = ghost.GetComponents<MonoBehaviour>();
        foreach (var component in components)
        {
            if (component is IBlock)
            {
                ((IBlock)component).PlaceBlock();
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
