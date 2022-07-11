using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMovementController : CharacterComponent
{
    public float speed;
    public float rotationSpeed;


    new IEnumerator Start()
    {
        base.Start();

        yield return null;

        InputLocator.service.CameraFollowObject(ownCharacter.position);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement(ownCharacter, InputLocator.service.gameInput);
        ProcessDirection(ownCharacter, InputLocator.service.gameInput, Time.deltaTime);
    }



    private void ProcessMovement(ICharacter character, GameInput gameInput)
    {
        if (character.state.lockPositionControl)
            return;

        if (gameInput.movement == Vector2.zero)
            return;

        var direction2d = character.direction.forward;
        direction2d.y = 0;
        direction2d = direction2d.normalized;

        var result = direction2d * gameInput.movement.y + Vector3.Cross(Vector3.up, direction2d) * gameInput.movement.x;

        character.movement.SetSpeed(speed * result.normalized);
    }

    private void ProcessDirection(ICharacter character, GameInput gameInput, float deltaTime)
    {
        if (character.state.lockDirectionControl)
            return;

        var targetDirection = gameInput.lookDirection;
        targetDirection.y = 0;
        targetDirection = targetDirection.normalized;

        var realTarget = Vector3.RotateTowards(character.direction.forward, targetDirection, rotationSpeed * Mathf.Deg2Rad * deltaTime, 2);
        // Debug.Log($"Current direction {character.direction.forward}, target direction {targetDirection}, real target {realTarget}");

        character.direction.SetDirection(realTarget);
    }
}
