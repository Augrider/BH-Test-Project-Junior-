using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class EventQueueController : IEventQueue
{
    //TODO: Find better way to handle EventQueue and their user

    public event Action<int, int> OnEntityHit;

    private EventQueue<int, int> onHitEventQueue = new EventQueue<int, int>();


    public EventQueueController()
    {
        onHitEventQueue.OnEventRaise += CallOnHit;
    }


    [Command(requiresAuthority = false)]
    public void EnqueueOnEntityHit(int hitPlayerIndex, int hitterPlayerIndex)
    {
        onHitEventQueue.EnqueueEvent(hitPlayerIndex, hitterPlayerIndex);
    }


    [Server]
    public void ResolveEvents()
    {
        onHitEventQueue.ResolveEvents();
    }



    private void CallOnHit(int hitPlayerIndex, int hitterPlayerIndex) => OnEntityHit?.Invoke(hitPlayerIndex, hitterPlayerIndex);
}
