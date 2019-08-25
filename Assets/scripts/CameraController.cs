using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float rollSpeed;
    private Camera camera;
    private Func<Vector3> GetCameraFollowPositionFunc;

    [SerializeField] private float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    public void Init(Func<Vector3> GetCameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    public void SetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    // Update is called once per frame
    void Update()
    {
        /* Find where the player in incase we need the camera to chase them. */
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z; // Constrain z axis
        cameraFollowPosition.x = transform.position.x; // Constrain x axis

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);

        Vector3 followThresholdPosition = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.67f, camera.nearClipPlane));

        if (distance > 0 && cameraFollowPosition.y > followThresholdPosition.y)
        {
            Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * followSpeed * Time.deltaTime;
            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            if (distanceAfterMoving > distance)
            {
                /* Overshot the target position. */
                transform.position = cameraFollowPosition;
            }

            transform.position = newCameraPosition;
        }
        else
        {
            transform.Translate(0, rollSpeed, 0);
        }

    }
}
