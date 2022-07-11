using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInput : IInputOperation
{
    public void Run(IInputOperationIO operationIO, float deltaTime)
    {
        for (int i = 0; i < operationIO.playersAmount; i++)
            ProcessInput(operationIO.players[i], operationIO.controlParameters);
    }



    /// <summary>
    /// Handle ability input and invoke player ability
    /// </summary>
    private void ProcessInput(PlayerOperationData player, PlayerControlParameters controlParameters)
    {
        if (player.input.useAbility)
            player.character.ability.Invoke(player.character, player.input.abilityDirection);
    }
}
