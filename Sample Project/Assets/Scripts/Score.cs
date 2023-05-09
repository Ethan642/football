using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() && other.GetComponent<FootballController>().footballHolder && other.GetComponent<FootballController>().footballHolder.GetComponentInChildren<Football>())
        {
            print("work");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
