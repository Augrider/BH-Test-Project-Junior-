using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ScoreRecord
{
    public string playerName;
    public int playerScore;


    public ScoreRecord(int score, string playerName)
    {
        this.playerName = playerName;
        this.playerScore = score;
    }
}
