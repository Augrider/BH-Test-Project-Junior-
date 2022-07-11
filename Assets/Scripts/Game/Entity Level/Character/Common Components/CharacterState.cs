using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

internal class CharacterState : NetworkBehaviour, ICharacterState
{
    public bool lockPositionControl { get => _lockPositionControl; set => _lockPositionControl = value; }
    public bool lockDirectionControl { get => _lockDirectionControl; set => _lockDirectionControl = value; }

    public bool abilityOnCooldown { get => _abilityOnCooldown; set => _abilityOnCooldown = value; }
    public bool invulnerable { get => _invulnerable; set => _invulnerable = value; }

    int ICharacterState.playerIndex { get => _playerIndex; set => _playerIndex = value; }

    [SyncVar] private bool _lockPositionControl;
    [SyncVar] private bool _lockDirectionControl;

    [SyncVar] private bool _abilityOnCooldown;
    [SyncVar] private bool _invulnerable;

    [SyncVar] private int _playerIndex;
}
