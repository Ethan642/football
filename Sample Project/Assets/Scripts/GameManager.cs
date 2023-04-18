using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform thePlayer;

    public Transform[] teamMates;
    public Transform[] enemies;
    public Transform footBall;
    public Transform ballFollow;

    public Vector3 playerPosition()
    {
        return thePlayer.position;
    }
    void Start()
    {
       // Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //ballFollow.position = new Vector3(footBall.position.x, ballFollow.position.y, ballFollow.position.z);
    }
}
