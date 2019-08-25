using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosion;
    public float radius = 5.0F;
    public float power = 1.0F;
    public float dropTime = 1;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= dropTime)
        {
            Explode();
        }
    }

    void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        foreach (Collider2D hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Debug.Log(rb);
                var force = (rb.transform.position - explosionPos).normalized * power;
                if (hit.gameObject.tag == "Player") {
                    force = force / 10;
                }
                rb.AddForce(force, ForceMode2D.Impulse);
            }
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public static void AddExplosionForce(Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        var dir = (body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        body.AddForce(dir.normalized * explosionForce);
    }
}
