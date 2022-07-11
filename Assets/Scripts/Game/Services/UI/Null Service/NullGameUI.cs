using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class NullGameUI : IGameUI
{
    public void OnStartGame(Action onStartGameCallback)
    {
        onStartGameCallback?.Invoke();
    }

    public void OnGameOver(ScoreRecord[] winners, Action onGameOverCallback)
    {
        onGameOverCallback?.Invoke();
    }


    public void RefreshScore(ScoreRecord[] scoreRecords) { }
}
