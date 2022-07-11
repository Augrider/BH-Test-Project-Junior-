using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for providing game state control
/// </summary>
public interface IGameState
{
    void StartGame();
    void EndGame(ScoreRecord[] winners);

    int GetScore(int playerIndex);
    ScoreRecord[] GetAllScoreRecords();

    void SetScore(int playerIndex, int score);
    void AddScore(int playerIndex, int score);
}
