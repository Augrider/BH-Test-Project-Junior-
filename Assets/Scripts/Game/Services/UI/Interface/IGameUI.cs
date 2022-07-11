using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameUI
{
    /// <summary>
    /// Set UI to play start sequence and do callback after
    /// </summary>
    /// <param name="onStartGameCallback">Optional callback</param>
    void OnStartGame(Action onStartGameCallback = null);

    /// <summary>
    /// Set UI to play end game sequence and do callback after
    /// </summary>
    /// <param name="winners">Winners of the current game</param>
    /// <param name="onGameOverCallback">Optional callback</param>
    void OnGameOver(ScoreRecord[] winners, Action onGameOverCallback = null);

    /// <summary>
    /// Refresh Score Board
    /// </summary>
    /// <param name="scoreRecords">Score records of every player</param>
    void RefreshScore(ScoreRecord[] scoreRecords);
}
