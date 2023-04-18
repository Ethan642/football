using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TeamInfo", menuName = "ScriptableObjects/Team Information", order = 1)]
public class TeamIntel : ScriptableObject
{

    // Start is called before the first frame update

    public string teamName;
    public Texture2D logo;
    public int Intelligence;
    public Color teamColor;
}