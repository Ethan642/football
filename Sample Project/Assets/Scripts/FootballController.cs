using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballController : MonoBehaviour
{
    public Transform footballHolder;
    public Transform third;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && footballHolder.GetComponentInChildren<Football>())
        {
            Football football = footballHolder.GetComponentInChildren<Football>();
            /*
            third.transform.parent = football.transform;
            third.transform.localPosition = Vector3.zero;
            third.GetComponentInChildren<Camera>().transform.localPosition = new Vector3(0, 1, -3);
            */
            football.throwBall(transform.GetComponentInChildren<Camera>().transform.forward, 50f, third);
        }
    }
}
