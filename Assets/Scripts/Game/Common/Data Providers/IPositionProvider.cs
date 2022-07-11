using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPositionProvider
{
    Vector3 value { get; }

    void SetPosition(Vector3 value);
}