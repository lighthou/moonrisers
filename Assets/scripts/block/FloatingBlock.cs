using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBlock : MonoBehaviour
{
    [SerializeField] private float frequency;
    [SerializeField] private float magnitude;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        transform.position = position + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
