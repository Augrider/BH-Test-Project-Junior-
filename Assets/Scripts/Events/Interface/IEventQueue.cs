using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;


/// <summary>
/// Interface for event system
/// </summary>
/// <remarks>
/// Events should be processed by server, and can be sent both from clients and server.
/// But they must contain only simple, allowed for serialization data. And this data should be synchronized
/// Events with interfaces can only be sent by server
/// </remarks>
public interface IEventQueue
{
    event System.Action<int, int> OnEntityHit;


    void EnqueueOnEntityHit(int hitPlayerIndex, int hitterPlayerIndex);

    /// <summary>
    /// Resolve all events currently in queue
    /// </summary>
    void ResolveEvents();
}