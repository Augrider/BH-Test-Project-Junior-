using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractions
{
    ITriggerComponent trigger { get; }

    void OnCollision(ICharacter self, ICharacter other);
}
