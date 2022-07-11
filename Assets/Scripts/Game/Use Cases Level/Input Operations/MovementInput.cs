using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : IInputOperation
{
    public void Run(IInputOperationIO operationIO, float deltaTime)
    {
        for (int i = 0; i < operationIO.playersAmount; i++)
            ProcessInput(operationIO.players[i], operationIO.controlParameters, deltaTime);
    }


    /// <summary>
    /// Handle movement input and set movement speed
    /// </summary>
    private void ProcessInput(PlayerOperationData player, PlayerControlParameters controlParameters, float deltaTime)
    {
        if (player.character.state.lockPositionControl)
            return;

        if (player.input.movement == Vector2.zero)
            return;

        var direction2d = player.character.direction.forward;
        direction2d.y = 0;
        direction2d = direction2d.normalized;

        var result = direction2d * player.input.movement.y + Vector3.Cross(Vector3.up, direction2d) * player.input.movement.x;

        player.character.movement.SetSpeed(controlParameters.speed * result.normalized);
    }
}
