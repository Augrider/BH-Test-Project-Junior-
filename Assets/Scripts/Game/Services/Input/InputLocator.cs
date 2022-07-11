using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputLocator
{
    private static IInput nullService { get; } = new NullInput();
    public static IInput service { get; private set; } = nullService;


    public static void Provide(IInput value)
    {
        service = value != null ? value : nullService;
    }
}
