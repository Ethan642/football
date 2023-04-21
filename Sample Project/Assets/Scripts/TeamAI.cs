using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamAI : MonoBehaviour
{
    public float JumpPower = 20f;
    public CharacterController controller;
    public float RunSpeed = 10;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Transform playerModel;
    public Transform footballHolder;
    bool jumping;
    public TeamIntel aiInfo;

    public string role;
    public int pos;

    public GameManager manager;

    public float Gravity = 20;

    public Transform ballPos;

    Vector3 theMove;
    Vector3 velocity;
    Vector3 initPosition;

    float turnThing;

    float lastPushed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        initPosition = transform.position;
    }

    public void aiMove(Vector3 direction)
    {

    }

    public void applyVelocity(Vector3 force)
    {
        velocity += force;
    }
    private void OnTriggerEnter(Collider other)
    {
        Transform possible = other.transform;
        if (possible.tag == "GoodTeam" && possible != transform && lastPushed > .1f)
        {
            lastPushed = 0;
            applyVelocity(possible.forward * 10f);
        }
    }

    public void jump()
    {
        jumping = true;
        velocity.y += Mathf.Sqrt(JumpPower * -2 * -Gravity);
    }

    // Update is called once per frame
    void Update()
    {

        bool isGrounded = Physics.CheckSphere(groundCheck.position, .2f, groundMask);

        Vector3 direction = Vector3.zero;//cam.transform.right * horizontal + new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * vertical;
        direction.Normalize();

        if (isGrounded)
            theMove = Vector3.Lerp(theMove, direction * RunSpeed * Time.deltaTime, 4f * Time.deltaTime);



        if (direction.magnitude >= .1f && isGrounded)
        {
            float possibleLook = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float smoothTurn = Mathf.SmoothDampAngle(transform.eulerAngles.y, possibleLook, ref turnThing, .25f);
            transform.rotation = Quaternion.Euler(0, smoothTurn, 0);
        }


        controller.Move(theMove);



        velocity.y += -Gravity * Time.deltaTime;


        velocity = Vector3.Lerp(velocity, new Vector3(0, velocity.y, 0), Time.deltaTime * 1);

        lastPushed += Time.deltaTime;

        if (isGrounded && !jumping)
        {
            velocity.y = 0;
        }
        jumping = false;
        controller.Move(velocity * Time.deltaTime);
    }
}
