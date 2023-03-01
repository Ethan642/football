using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float JumpPower = 20f;
    public CharacterController controller;
    public float RunSpeed = 10;
    public Transform groundCheck;
    public Transform Third;
    public Camera cam;
    public LayerMask groundMask;
    public float MouseSensitivity;

    float x;
    float y;
    float Gravity = 0;

    Vector3 theMove;

    float turnThing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        x += Input.GetAxisRaw("Mouse X") * MouseSensitivity * Time.deltaTime;
        y = Mathf.Clamp(y - Input.GetAxisRaw("Mouse Y") * MouseSensitivity * Time.deltaTime, -90, 90);
        bool isGrounded = Physics.CheckSphere(groundCheck.position, .4f, groundMask);

        Vector3 direction = cam.transform.right * horizontal + new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * vertical;
        direction.Normalize();


        
        if (direction.magnitude >= .1f)
        {
            float possibleLook = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float smoothTurn = Mathf.SmoothDampAngle(transform.eulerAngles.y, possibleLook, ref turnThing, .1f);
            transform.rotation = Quaternion.Euler(0, smoothTurn, 0);
        }

        theMove = Vector3.Lerp(theMove, direction, .5f);
        controller.Move(theMove * RunSpeed * Time.deltaTime);

        Third.rotation = Quaternion.Euler(y, x, 0f);

        Gravity *= -2;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Gravity = 20;
        }
    }
}
