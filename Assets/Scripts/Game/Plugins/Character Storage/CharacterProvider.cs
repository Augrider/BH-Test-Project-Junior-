using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CharacterProvider : CharacterComponent
{
    [SerializeField] private GameObject charObject;


    protected override void Start()
    {
        base.Start();

        CharacterStorageLocator.service.ProvideCharacter(ownCharacter.playerIndex, charObject, ownCharacter);
    }
}
