using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class NullPlayerManagement : IPlayerManagement
{
    public int playerCount => 0;
    public PlayerData[] allPlayers => new PlayerData[0];

    public event Action<int> PlayerChanged;

    public void AddPlayer(int playerIndex)
    {
        throw new System.NotImplementedException();
    }

    public void ChangeColor(int playerIndex, Color value)
    {
        throw new NotImplementedException();
    }

    public void ChangeName(int playerIndex, string value)
    {
        throw new NotImplementedException();
    }

    public void ResetInput()
    {
        throw new NotImplementedException();
    }

    public PlayerData GetPlayer(int hitPlayerIndex)
    {
        throw new System.NotImplementedException();
    }

    public void RemovePlayer(int playerIndex)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateInput(int playerIndex, GameInput input)
    {
        throw new System.NotImplementedException();
    }
}
