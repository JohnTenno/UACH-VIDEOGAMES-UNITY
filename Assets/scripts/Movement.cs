using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    private Rigidbody2D rb;
    public Animator pecaoAnimator;
    private Vector2 movement;
    private Vector2 screenBounds;
    private CameraMovement cameraMovement;
    public GameObject diePanel;
    public GameObject diePanelByBottomZone;

    [SerializeField] protected PauseResumen pauseGame;
    [SerializeField] private InputActionReference moveActionToUse;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraMovement = FindObjectOfType<CameraMovement>();
    }

    private void OnEnable()
    {
        moveActionToUse.action.Enable();
    }

    private void OnDisable()
    {
        moveActionToUse.action.Disable();
    }

    private void Start()
    {
        UpdateScreenBounds();
    }

    private void Update()
    {
        movement = moveActionToUse.action.ReadValue<Vector2>();

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

 
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        UpdateScreenBounds();
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed; 


        Vector3 newPosition = rb.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x, screenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y, screenBounds.y);
        rb.position = newPosition;
    }

    private void UpdateScreenBounds()
    {
        if (cameraMovement != null)
        {
            screenBounds = cameraMovement.GetScreenBounds();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null) return;

        switch (other.tag)
        {
            case "turtle":
                HandleTurtleCollision();
                break;
            case "pecao":
                HandlePecaoCollision();
                break;
            case "killBottom":
                HandleKillBottomCollision();
                break;
            default:
                Debug.LogWarning("Etiqueta no manejada: " + other.tag);
                break;
        }
    }

    private void HandleTurtleCollision()
    {
        Destroy(gameObject);
        pauseGame?.PauseByDie();
        if (diePanel != null)
        {
            diePanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("diePanel no está asignado.");
        }
    }

    private void HandlePecaoCollision()
    {
        if (pecaoAnimator != null)
        {
            pecaoAnimator.SetTrigger("pecaoMovement");
        }
        else
        {
            Debug.LogWarning("pecaoAnimator no está asignado.");
        }
    }

    private void HandleKillBottomCollision()
    {
        pauseGame?.PauseByDie();
        if (diePanelByBottomZone != null)
        {
            diePanelByBottomZone.SetActive(true);
        }
        else
        {
            Debug.LogWarning("pauseGame no está asignado.");
        }
    }
}
