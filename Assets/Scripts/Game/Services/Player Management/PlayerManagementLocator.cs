using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerManagementLocator
{
    private static IPlayerManagement nullService { get; } = new NullPlayerManagement();
    public static IPlayerManagement service { get; private set; } = nullService;


    public static void Provide(IPlayerManagement value)
    {
        service = value != null ? value : nullService;
    }
}
