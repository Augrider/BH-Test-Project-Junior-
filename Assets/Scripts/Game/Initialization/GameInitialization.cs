using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

/// <summary>
/// Class that handles proper initialization of Game Scene and it's controllers
/// </summary>
public class GameInitialization : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    [SerializeField] private GameLoop gameLoop;
    [SerializeField] private GameRules gameRules;
    [SerializeField] private GameState gameState;

    [SerializeField] private float loadingStepDelay = 0.1f;


    //TODO: Initialization (character creation, operations creation...) should be done inside loading script
    [Server]
    IEnumerator Start()
    {
        yield return new WaitForSeconds(loadingStepDelay);

        CreateCharacters();

        yield return new WaitForSeconds(loadingStepDelay);

        ProvideOperationsIO();
        ProvideOperations();

        ProvideRules();

        yield return new WaitForSeconds(loadingStepDelay);

        gameState.StartGame();
    }



    [Server]
    private void CreateCharacters()
    {
        var connections = NetworkFunctions.GetConnections();

        foreach (var connection in connections)
            CreateCharacter(connection, NetworkFunctions.GetSpawnPosition());
    }


    private void ProvideOperationsIO()
    {
        gameLoop.inputOperationIO = new InputOperationIO(gameData);
    }

    private void ProvideOperations()
    {
        gameLoop.operations = new IInputOperation[]
        {
            new MovementInput(),
            new DirectionInput(),
            new AbilityInput()
        };
    }


    private void ProvideRules()
    {
        gameRules.ruleOnHit = new RuleInvulnerableOnHit();
        gameRules.ruleGameOverOnScore = new RuleGameOverOnScore();
    }


    private static void CreateCharacter(NetworkConnectionToClient conn, Transform spawnTransform)
    {
        var playerColor = PlayerManagementLocator.service.GetPlayer(conn.connectionId).playerColor;
        (var charObject, var character) = CharacterStorageLocator.service.CreateCharacter(conn.connectionId, spawnTransform.position, spawnTransform.forward);

        NetworkServer.Spawn(charObject, conn);
        character.color.SetColor(playerColor);
    }
}
