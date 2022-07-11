using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    int playerIndex { get; }

    IPositionProvider position { get; }
    IDirectionProvider direction { get; }
    IColorProvider color { get; }

    ICharacterState state { get; }

    IMovement movement { get; }
    IInteractions interactions { get; }
    IAbility ability { get; }
}
