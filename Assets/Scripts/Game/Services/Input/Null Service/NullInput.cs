using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullInput : IInput
{
    public GameInput gameInput { get; } = new GameInput();

    event Action<GameInput> IInput.OnInputChanged
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    public void CameraFollowObject(IPositionProvider positionProvider) { }
    public void CameraFollowObject(IPositionProvider positionProvider, Vector3 direction) { }
}