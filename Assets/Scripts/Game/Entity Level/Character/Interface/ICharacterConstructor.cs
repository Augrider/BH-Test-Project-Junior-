using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterConstructor
{
    void ProvideMovement(IMovement value);
    void ProvideInteractions(IInteractions value);
    void ProvideAbility(IAbility value);
}
