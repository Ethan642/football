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
    public Transform playerModel;
    public Animator animator;
    bool jumping;

    public int timesHit;

    float lastPushed;

    float x;
    float y;
    public float Gravity = 20;



    Vector3 theMove;
    Vector3 velocity;

    float turnThing;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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

            if (transform.GetComponent<FootballController>().footballHolder.GetComponentInChildren<Football>())
                timesHit += 1;
            transform.GetComponent<AudioSource>().Play();
            if (timesHit > 4 && transform.GetComponent<FootballController>().footballHolder.GetComponentInChildren<Football>())
            {
                transform.GetComponent<FootballController>().footballHolder.GetComponentInChildren<Football>().transform.parent = null;
                transform.GetComponent<FootballController>().footballHolder.GetComponentInChildren<Football>().transform.GetComponent<Rigidbody>().isKinematic = false;
                timesHit = 0;
            }

            applyVelocity(possible.forward * 10f);
            animator.SetTrigger("Shove");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        x += Input.GetAxisRaw("Mouse X") * MouseSensitivity * Time.deltaTime;
        y = Mathf.Clamp(y - Input.GetAxisRaw("Mouse Y") * MouseSensitivity * Time.deltaTime, -90, 90);
        bool isGrounded = Physics.CheckSphere(groundCheck.position, .2f, groundMask);

        Vector3 direction = cam.transform.right * horizontal + new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * vertical;
        direction.Normalize();

        if (isGrounded)
            theMove = Vector3.Lerp(theMove, direction * RunSpeed * Time.deltaTime, 4f * Time.deltaTime);

        print(theMove.magnitude);
        animator.SetFloat("Speed", Mathf.Abs(theMove.magnitude));
        if (direction.magnitude >= .1f && isGrounded)
        {
            float possibleLook = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float smoothTurn = Mathf.SmoothDampAngle(transform.eulerAngles.y, possibleLook, ref turnThing, .25f);
            transform.rotation = Quaternion.Euler(0, smoothTurn, 0);
        }

        
        controller.Move(theMove);

        Third.rotation = Quaternion.Euler(y, x, 0f);

        

        velocity.y += -Gravity * Time.deltaTime;
        velocity = Vector3.Lerp(velocity, new Vector3(0, velocity.y, 0), Time.deltaTime * 1);

        if (isGrounded && !jumping)
        {
            velocity.y = 0;
        }

        lastPushed += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumping = true;
            velocity.y += Mathf.Sqrt(JumpPower * -2 * -Gravity);
            
        }
        jumping = false;
        controller.Move(velocity * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("guy");
    }
}