using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    /// <summary>
    /// Unique player identifier, usually it's connectionID
    /// </summary>
    public int playerIndex;
    public GameInput gameInput;

    public string playerName;
    public Color playerColor;
}
