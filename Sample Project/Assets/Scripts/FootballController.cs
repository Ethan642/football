using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballController : MonoBehaviour
{
    public Transform footballHolder;
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
            football.throwBall(transform.GetComponentInChildren<Camera>().transform.forward, 50f);
        }
    }
}
