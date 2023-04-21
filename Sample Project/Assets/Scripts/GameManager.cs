using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform thePlayer;

    public Transform teamMate;
    public Transform[] enemies;
    public Transform footBall;
    public Transform ballFollow;

    public Transform[] teamPositions;

    public int homeScore;
    public int vistorScore;

    public Vector3 playerPosition()
    {
        return thePlayer.position;
    }

    public void StartGame()
    {
        Transform[] used = teamPositions;
        List<Transform> transforms = new List<Transform>();
        for (int i = 0; i < teamPositions.Length; i++)
        {
            transforms.Add(teamPositions[i]);
        }

        int usedThing = 5;
        print("should");
        int test = Random.Range(0, transforms.Count - 1);
        thePlayer.position = transforms[test].position;
        transforms.Remove(transforms[test]);
        while (usedThing > 0)
        {
            int thing = Random.Range(0, transforms.Count - 1);
            print(transforms[thing]);
            Instantiate(teamMate, transforms[thing].position, Quaternion.identity, null);
            transforms.Remove(transforms[thing]);
            usedThing--;
        }
        

    }

    void Start()
    {
        StartGame();
       // Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //ballFollow.position = new Vector3(footBall.position.x, ballFollow.position.y, ballFollow.position.z);
    }
}
