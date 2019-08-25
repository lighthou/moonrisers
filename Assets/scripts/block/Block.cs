using UnityEngine;

public class Block : MonoBehaviour, IBlock
{
    public int health { get; private set; }

    public void Start()
    {
        health = 100;
    }

    public void PlaceBlock()
    {
        health = 100;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Blam!");
            TakeDamage(20);
        }
    }
}