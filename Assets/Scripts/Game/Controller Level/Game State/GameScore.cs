using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameScore : MonoBehaviour
{
    //Note: we can keep ScoreRecord here, but this will duplicate character name

    /// <summary>
    /// Player Index/Current Score pair
    /// </summary>
    private Dictionary<int, int> currentScore = new Dictionary<int, int>();


    public void AddPlayer(int playerIndex, int score)
    {
        if (currentScore.ContainsKey(playerIndex))
            throw new System.Exception();

        currentScore.Add(playerIndex, score);
    }

    public void RemovePlayer(int playerIndex)
    {
        if (!currentScore.ContainsKey(playerIndex))
            throw new System.Exception();

        currentScore.Remove(playerIndex);
    }


    public int GetScore(int playerIndex) => currentScore[playerIndex];

    public ScoreRecord[] GetAllScoreRecords()
    {
        var players = PlayerManagementLocator.service.allPlayers;
        var scores = new List<ScoreRecord>(players.Length);

        foreach (var player in players)
        {
            var score = GetScore(player.playerIndex);
            scores.Add(new ScoreRecord(score, player.playerName));
        }

        return scores.ToArray();
    }


    public void SetScore(int playerIndex, int score)
    {
        if (!currentScore.ContainsKey(playerIndex))
            throw new System.Exception();

        currentScore[playerIndex] = score;
    }

    public void AddScore(int playerIndex, int score)
    {
        if (!currentScore.ContainsKey(playerIndex))
            throw new System.Exception();

        currentScore[playerIndex] += score;
    }
}
