using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for object that controls coroutine operations
/// </summary>
public interface ICoroutineObject
{
    /// <summary>
    /// Start coroutine on coroutine object (this coroutine is client side only)
    /// </summary>
    void StartCoroutine(IEnumerator coroutine);
}
