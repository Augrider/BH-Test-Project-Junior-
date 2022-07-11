using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUILocator
{
    private static IGameUI nullService { get; } = new NullGameUI();
    public static IGameUI service { get; private set; } = nullService;


    public static void Provide(IGameUI value)
    {
        service = value != null ? value : nullService;
    }
}
