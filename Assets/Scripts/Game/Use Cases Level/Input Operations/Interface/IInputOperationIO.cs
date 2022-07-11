using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for providing IO to input operations
/// </summary>
public interface IInputOperationIO
{
    /// <summary>
    /// Current players amount
    /// </summary>
    int playersAmount { get; }

    /// <summary>
    /// Array of all characters and inputs
    /// </summary>
    PlayerOperationData[] players { get; }

    /// <summary>
    /// Parameters for character control (acceleration and rotation speed)
    /// </summary>
    PlayerControlParameters controlParameters { get; }

    /// <summary>
    /// Refresh current IO state
    /// </summary>
    void Refresh();
}
