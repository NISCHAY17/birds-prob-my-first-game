using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlsWork : MonoBehaviour
{
    private Camera cam;
    private Collider2D col;
    private Rigidbody2D rb;
    private bool dragging;
    private Vector3 offset;
    public Vector3 startingposition; 
    [SerializeField] float maxDragDistance = 5f;
    public float launchForce = 5f; 
    private LineRenderer lineRenderer;

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
        lineRenderer = GetComponent<LineRenderer>();
        startingposition = transform.position;
        lineRenderer.positionCount = 2; // Ensure we have 2 points
        lineRenderer.SetPosition(0, startingposition);
        lineRenderer.SetPosition(1, startingposition); // Initialize second point
        lineRenderer.enabled = false; // Hide line initially
        if (rb != null) rb.gravityScale = 0f; // Start with no gravity
    }

    void OnMouseUp()
    {
        Vector3 directionmagnitude = startingposition - transform.position;
        rb.AddForce(directionmagnitude * launchForce, ForceMode2D.Impulse);
        if (rb != null) rb.gravityScale = 1f; // Enable gravity after launch
        lineRenderer.enabled = false; // Hide line after launch
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
                lineRenderer.enabled = true; // Show line when dragging starts
                lineRenderer.SetPosition(0, startingposition); // Ensure start is anchored
            }
        }

        // continue dragging while held
        if (dragging && Mouse.current.leftButton.isPressed)
        {
            float z = cam.WorldToScreenPoint(transform.position).z;
            Vector3 worldPoint = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, z));
            Vector3 newPosition = worldPoint + offset;
            
            // Clamp drag distance to maxDragDistance
            float distance = Vector3.Distance(newPosition, startingposition);
            if (distance > maxDragDistance)
            {
                Vector3 direction = (newPosition - startingposition).normalized;
                newPosition = startingposition + direction * maxDragDistance;
            }
            
            transform.position = newPosition;
            lineRenderer.SetPosition(1, transform.position); // Update line end to bird's position
        }

        // stop dragging on release
        if (dragging && Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
            // Don't change gravity here - let OnMouseUp() handle it
        }

        // keyboard helpers
        if (Keyboard.current != null && rb != null)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame) rb.gravityScale = 10f;
            if (Keyboard.current.eKey.wasPressedThisFrame) rb.gravityScale = -20f;
        }
        if (FindAnyObjectByType<Enemy>(FindObjectsInactive.Exclude) == null)
        {
            Debug.Log("You Win!");
            var Levelrn = SceneManager.GetActiveScene().buildIndex  + 1 ;
            SceneManager.LoadScene(Levelrn);
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
        Invoke(nameof(reloadlevel), 5);
        }
        
        void reloadlevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
}

