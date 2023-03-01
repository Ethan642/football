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

    public void throwFuﬂball(Vector3 direction, float Power)
    {
        transform.parent = null;
        transform.LookAt(direction);
        rigidbody.AddForce(direction * Power * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
