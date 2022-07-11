using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for main game loop controls
/// </summary>
public interface IGameLoopControl
{
    /// <summary>
    /// Is game loop currently active and updating?
    /// </summary>
    bool enabled { get; set; }
}
