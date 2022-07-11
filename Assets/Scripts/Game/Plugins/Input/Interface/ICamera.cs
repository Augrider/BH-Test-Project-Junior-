using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICamera
{
    Vector3 lookDirection { get; }
    Vector3 abilityDirection { get; }

    void Follow(IPositionProvider positionProvider);
    void Turn(Vector2 cameraInput);
    void SetDirection(Vector3 direction);
}
