using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private Rigidbody rb;

    private Vector2 look;
    private Vector3 move;

    private float lookSense = 1.5f;
    private float moveSpeed = 4f;
    //private float jumpHeight = 5f;
    private float horizontalInput, verticalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        look.x += Input.GetAxisRaw("Mouse X") * lookSense;
        look.y += Input.GetAxisRaw("Mouse Y") * lookSense;
        look.y = Mathf.Clamp(look.y, -90, 90);
        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x - 90, 0);

        horizontalInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        verticalInput = Input.GetAxisRaw("Vertical") * moveSpeed;
        move = transform.forward * verticalInput + transform.right * horizontalInput;
        move.y = rb.linearVelocity.y;
        rb.linearVelocity = move;

        /*if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpHeight, rb.linearVelocity.z);
        }*/
    }
}