using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float JumpPower = 20f;
    public CharacterController controller;
    public float RunSpeed = 10;
    public Transform groundCheck;
    public Camera cam;
    public LayerMask groundMask;

    float x;
    float y;
    float Gravity = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        x += Input.GetAxisRaw("Mouse X");
        y = Mathf.Clamp(y + Input.GetAxisRaw("Mouse Y"), -90, 90);
        bool isGrounded = Physics.CheckSphere(groundCheck.position, .4f, groundMask);

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= .1f)
        {
            controller.Move(direction * RunSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Gravity += 20;
        }
    }
}
