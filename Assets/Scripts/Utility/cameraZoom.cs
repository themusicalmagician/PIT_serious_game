using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    public float panSpeed = 5f; // Adjust the speed of camera movement
    public float maxPanDistance = 10f; // Maximum distance the camera can pan in each direction

    private Vector3 lastMousePosition;

    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;

    private float velocity = 0f;
    private float smoothTime = 0.25f;

    [SerializeField] private Camera cam;
    [SerializeField] private float maxZoom;

    void Start()
    {
        zoom = cam.orthographicSize;
    }

    void Update()
    {
        // Camera Zooming
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        //Debug.Log("Zooming: Zoom Value = " + zoom);

        // Camera Panning
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(delta.x, delta.y, 0) * panSpeed * Time.deltaTime;

            // Limit camera movement to a maximum of 10 units in each direction
            Vector3 newPosition = transform.position + move;
            newPosition.x = Mathf.Clamp(newPosition.x, -maxPanDistance, maxPanDistance);
            newPosition.y = Mathf.Clamp(newPosition.y, -maxPanDistance, maxPanDistance);

            transform.position = newPosition;

            lastMousePosition = Input.mousePosition;
            Debug.Log("Panning: New Position = " + newPosition);
        }
    }
}
