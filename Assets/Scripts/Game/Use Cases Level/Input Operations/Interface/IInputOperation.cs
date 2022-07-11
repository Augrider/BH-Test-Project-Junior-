using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for every Operation that handles game input of all players
/// </summary>
public interface IInputOperation
{
    /// <summary>
    /// Update characters state based on input
    /// </summary>
    /// <param name="operationIO">Provided IO for input operations</param>
    /// <param name="deltaTime">Time passed since last frame</param>
    void Run(IInputOperationIO operationIO, float deltaTime);
}
