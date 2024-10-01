using UnityEngine;

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
    [SerializeField] protected PauseResumen pauseGame;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraMovement = FindObjectOfType<CameraMovement>();
        UpdateScreenBounds();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");   
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        } 
        rb.velocity = movement * moveSpeed;

        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        UpdateScreenBounds(); 

        Vector3 newPosition = rb.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x, screenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y, screenBounds.y);

        rb.position = newPosition;
    }

    void UpdateScreenBounds()
    {
        if (cameraMovement != null)
        {
            screenBounds = cameraMovement.GetScreenBounds(); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("turtle"))
        {

            Destroy(gameObject);
            pauseGame.PauseByDie();
            diePanel.SetActive(true);
        }
         if (other.CompareTag("pecao"))
        {
            pecaoAnimator.SetTrigger("pecaoMovement");
        }
    }

}
