using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorProvider
{
    Color value { get; }

    void SetColor(Color value);
}
