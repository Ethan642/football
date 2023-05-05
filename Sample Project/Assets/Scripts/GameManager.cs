using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform thePlayer;

    public Transform teamMate;
    public List<Transform> teamMates;
    public List<Transform> enemies;
    public Transform footBall;
    public Transform ballFollow;


    // ui

    public Transform timeUI;



    public int gameProgress;

    public float time;

    string[] roles = {"ball", "enemy"};

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

        int usedThing = 11;
        print("should");
        int test = Random.Range(0, transforms.Count - 1);
        thePlayer.position = transforms[test].position;
        thePlayer.rotation = Quaternion.Euler(0, 90f, 0);
        transforms.Remove(transforms[test]);
        while (usedThing > 0)
        {
            int thing = Random.Range(0, transforms.Count - 1);
            Transform newTeammate = Instantiate(teamMate, transforms[thing].position, Quaternion.Euler(0, -90f, 0), null);
            newTeammate.GetComponent<TeamAI>().manager = this;

            if (usedThing > 6)
            {
                newTeammate.GetComponent<TeamAI>().role = "ball";
            }
            else
            {
                newTeammate.GetComponent<TeamAI>().role = "enemy";
            }
            

            teamMates.Add(newTeammate);
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
        time += Time.deltaTime;
       // timeUI.GetComponent<TextMeshPro>().text = time.ToString();
        if (time > 120)
        {
            if (homeScore > vistorScore)
            {
                print("won!");
            } else if (homeScore == vistorScore)
            {
                print("tied");
            } else
            {
                print("lost!");
            }
        }
    }
}
