using UnityEngine;

public class Block : MonoBehaviour, IBlock
{
    public Particles particles;

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
        Instantiate(particles.explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(particles.destroy, mousePos, Quaternion.identity);
            Debug.Log("Blam!");
            TakeDamage(20);
        }
    }
}