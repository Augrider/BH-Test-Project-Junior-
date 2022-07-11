using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionProvider
{
    Vector3 forward { get; }

    void SetDirection(Vector3 value);
}