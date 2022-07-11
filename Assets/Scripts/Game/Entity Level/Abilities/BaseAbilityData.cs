using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all abilities
/// </summary>
/// <remarks>
/// Classes derived from that are not allowed to have their inner state.
/// All state should only exist in context of AbilityEffect coroutine
/// </remarks>
public abstract class BaseAbilityData : ScriptableObject
{
    public float cooldown = 0.1f;

    public abstract IEnumerator AbilityEffect(ICharacter self, Vector3 direction);
}
