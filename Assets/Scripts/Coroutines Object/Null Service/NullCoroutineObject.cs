using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class NullCoroutineObject : ICoroutineObject
{
    public void StartCoroutine(IEnumerator coroutine)
    {
        Debug.LogWarning("Null Coroutine Started");
    }
}
