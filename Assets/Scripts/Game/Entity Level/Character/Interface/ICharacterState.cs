using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState
{
    internal int playerIndex { get; set; }

    bool lockPositionControl { get; set; }
    bool lockDirectionControl { get; set; }

    bool abilityOnCooldown { get; set; }
    bool invulnerable { get; set; }
}
