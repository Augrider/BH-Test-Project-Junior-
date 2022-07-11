using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoroutineObjectLocator
{
    private static ICoroutineObject nullService { get; } = new NullCoroutineObject();
    public static ICoroutineObject service { get; private set; } = nullService;


    public static void Provide(ICoroutineObject value)
    {
        service = value != null ? value : nullService;
    }
}
