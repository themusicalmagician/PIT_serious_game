using UnityEngine;
using UnityEngine.EventSystems;

public class ImageZoom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float zoomSpeed = 0.5f; // Speed of zooming
    public float minZoom = 1f; // Minimum zoom level
    public float maxZoom = 3f; // Maximum zoom level

    private bool isZooming = false;
    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        if (isZooming)
        {
            float scrollInput = Input.mouseScrollDelta.y;
            float newZoom = Mathf.Clamp(transform.localScale.x + scrollInput * zoomSpeed, minZoom, maxZoom);
            transform.localScale = new Vector3(newZoom, newZoom, 1f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isZooming = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isZooming = false;
    }
}
