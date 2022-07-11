using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class DebugInitialization : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    [SerializeField] private GameLoop gameLoop;


    //TODO: Initialization (character creation, operations creation...) should be done inside loading script
    // [Server]
    IEnumerator Start()
    {
        yield return null;

        ProvideOperationsIO();
        ProvideOperations();
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
}
