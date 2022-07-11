using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineObject : MonoBehaviour, ICoroutineObject
{
    void Awake()
    {
        CoroutineObjectLocator.Provide(this);
    }

    void OnDestroy()
    {
        CoroutineObjectLocator.Provide(null);
    }



    void ICoroutineObject.StartCoroutine(IEnumerator coroutine) => StartCoroutine(coroutine);
}
