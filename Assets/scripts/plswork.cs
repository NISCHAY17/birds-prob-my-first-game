using UnityEngine;
using UnityEngine.InputSystem;

public class PlsWork : MonoBehaviour
{
    private Camera cam;
    private Collider2D col;
    private Rigidbody2D rb;
    private bool dragging;
    private Vector3 offset;

    void Awake()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (col == null) Debug.LogWarning("Add a Collider2D to this GameObject to enable dragging.");
    }

    void Start()
    {
        Debug.Log("plswork");
    }

    void Update()
    {
        if (Mouse.current == null || cam == null) return;

        Vector2 screenPos = Mouse.current.position.ReadValue();

        // start drag on press
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            float z = cam.WorldToScreenPoint(transform.position).z;
            Vector3 worldPoint = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, z));
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider == col)
            {
                dragging = true;
                offset = transform.position - worldPoint;
                if (rb != null) rb.gravityScale = 0f;
            }
        }

        // continue dragging while held
        if (dragging && Mouse.current.leftButton.isPressed)
        {
            float z = cam.WorldToScreenPoint(transform.position).z;
            Vector3 worldPoint = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, z));
            transform.position = worldPoint + offset;
        }

        // stop dragging on release
        if (dragging && Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
            if (rb != null) rb.gravityScale = 1f;
        }

        // keyboard helpers
        if (Keyboard.current != null && rb != null)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame) rb.gravityScale = 10f;
            if (Keyboard.current.eKey.wasPressedThisFrame) rb.gravityScale = -20f;
        }
    }
}

