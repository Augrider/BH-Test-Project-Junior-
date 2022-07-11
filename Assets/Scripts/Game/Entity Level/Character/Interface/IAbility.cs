using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void Invoke(ICharacter self, Vector3 direction);
}
