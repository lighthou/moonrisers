using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool rolling;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (rolling) {
            speed = 0.01f;
        } else {
            speed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);
    }
}
