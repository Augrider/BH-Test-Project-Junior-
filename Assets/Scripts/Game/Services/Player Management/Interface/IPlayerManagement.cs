using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerManagement
{
    int playerCount { get; }
    PlayerData[] allPlayers { get; }

    /// <summary>
    /// Event fired when player data changed. Not fired when input changed.
    /// </summary>
    event System.Action<int> PlayerChanged;

    PlayerData GetPlayer(int playerIndex);

    void AddPlayer(int playerIndex);
    void RemovePlayer(int playerIndex);

    void ChangeName(int playerIndex, string value);
    void ChangeColor(int playerIndex, Color value);

    void UpdateInput(int playerIndex, GameInput input);
    void ResetInput();
}
