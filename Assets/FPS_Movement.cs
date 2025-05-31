using UnityEngine;

public class FPS_Movement : MonoBehaviour
{
    public float mousesensitivity = 100f;
    public Transform playerbody;
    float xrotation = 0;
    public GameObject playercamera;
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool isgrounded;
    public float jumpheight = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        float mousex = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;
        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        playercamera.transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mousex);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
