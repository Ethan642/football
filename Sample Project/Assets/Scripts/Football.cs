using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void throwBall(Vector3 direction, float Power)
    {
        rigidbody.isKinematic = false;
        transform.parent = null;
        
        transform.LookAt(direction);
        
        //transform.rotation = Quaternion.Euler(transform.rotation.x - 90f, transform.rotation.y, transform.rotation.z);
        rigidbody.AddForce(direction * Power, ForceMode.Impulse);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.collider.transform.parent && other.collider.transform.parent.tag == "GoodTeam")
        {
            rigidbody.isKinematic = true;
            transform.parent = other.collider.transform.parent.GetComponent<FootballController>().footballHolder;
            transform.localPosition = new Vector3(-1.561642e-05f, 0, 4.589558e-05f);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
