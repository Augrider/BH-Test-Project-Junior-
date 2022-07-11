using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameLoop : MonoBehaviour, IGameLoopControl
{
    public IInputOperation[] operations { get; set; } = new IInputOperation[0];
    public IInputOperationIO inputOperationIO { get; set; }


    [Server]
    void Update()
    {
        inputOperationIO.Refresh();

        RunOperations(Time.deltaTime);
        ResolveEvents();
    }



    private void RunOperations(float deltaTime)
    {
        foreach (var operation in operations)
            operation.Run(inputOperationIO, deltaTime);
    }

    private void ResolveEvents()
    {
        EventQueueLocator.service.ResolveEvents();
    }
}
