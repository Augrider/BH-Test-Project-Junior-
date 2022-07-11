using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for providing IO to all game rules
/// </summary>
public interface IRulesIO
{
    IGameState gameState { get; }
    GameData gameData { get; }
    IGameLoopControl gameLoopControl { get; }
}
