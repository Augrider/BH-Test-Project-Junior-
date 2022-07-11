using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionInput : IInputOperation
{
    public void Run(IInputOperationIO operationIO, float deltaTime)
    {
        for (int i = 0; i < operationIO.playersAmount; i++)
            ProcessInput(operationIO.players[i], operationIO.controlParameters, deltaTime);
    }



    /// <summary>
    /// Handle direction input and set rotation
    /// </summary>
    private void ProcessInput(PlayerOperationData player, PlayerControlParameters controlParameters, float deltaTime)
    {
        if (player.character.state.lockDirectionControl)
            return;

        if (player.input.lookDirection == Vector3.zero)
            return;

        var targetDirection = player.input.lookDirection;
        targetDirection.y = 0;
        targetDirection = targetDirection.normalized;

        var realTarget = Vector3.RotateTowards(player.character.direction.forward, targetDirection, controlParameters.rotationSpeed * Mathf.Deg2Rad * deltaTime, 2);

        player.character.direction.SetDirection(realTarget);
    }
}
