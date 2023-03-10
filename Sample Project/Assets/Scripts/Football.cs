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
        rigidbody.AddForce(direction * Power, ForceMode.Impulse);
    }


    void OnCollisionEnter(Collision other)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
