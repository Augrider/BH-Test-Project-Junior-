using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterNetworkComponent : NetworkBehaviour
{
    [SerializeField] private Character _ownCharacter;
    protected ICharacter ownCharacter { get; private set; }


    protected virtual void Start()
    {
        this.ownCharacter = _ownCharacter;
    }
}
