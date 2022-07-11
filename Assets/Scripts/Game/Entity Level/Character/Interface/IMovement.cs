using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void SetSpeed(Vector3 value);
    void AddImpulse(Vector3 direction, float strength);
}
