using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterStorageLocator
{
    private static ICharacterStorage nullService { get; } = new NullCharacterStorage();
    public static ICharacterStorage service { get; private set; } = nullService;


    public static void Provide(ICharacterStorage value)
    {
        service = value != null ? value : nullService;
    }
}
