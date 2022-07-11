using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    /// <summary>
    /// Game Input struct that contains current client input
    /// </summary>
    GameInput gameInput { get; }
    event System.Action<GameInput> OnInputChanged;

    /// <summary>
    /// Set position provider for camera to follow
    /// </summary>
    void CameraFollowObject(IPositionProvider positionProvider);

    /// <summary>
    /// Set position provider for camera to follow
    /// </summary>
    void CameraFollowObject(IPositionProvider positionProvider, Vector3 direction);
}
