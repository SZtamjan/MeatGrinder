using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public CharacterController ctrl;
    public Transform playerBody;
    public Transform camTransform;

    public float playerSpeed = 10f;
    public float mouseSens = 500f;

    private float xRot = 0f;

    public LayerMask layerM;
    private bool grounded;
    public float gravity = -9.81f;
    private Vector3 velocity;

    public float jmpH = 3f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = GetComponent<Transform>();
        ctrl = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSens * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        
        camTransform.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        ctrl.Move(((transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"))) *
                  playerSpeed * Time.deltaTime);

        grounded = Physics.CheckSphere(playerBody.position, 0.1f, layerM);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            print("jumped");
            velocity.y = Mathf.Sqrt(jmpH * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        ctrl.Move(velocity * Time.deltaTime);

    }
}
