using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraController : MonoBehaviour, ICamera
{
    public abstract Vector3 lookDirection { get; }
    public abstract Vector3 abilityDirection { get; }

    public abstract void Follow(IPositionProvider positionProvider);
    public abstract void Turn(Vector2 cameraInput);
    public abstract void SetDirection(Vector3 direction);
}