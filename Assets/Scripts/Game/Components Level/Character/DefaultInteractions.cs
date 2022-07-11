using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInteractions : IInteractions
{
    public ITriggerComponent trigger { get; private set; }
    private float pushImpulse;


    public DefaultInteractions(TriggerComponent trigger, float pushImpulse = 0)
    {
        this.trigger = trigger;
        this.pushImpulse = pushImpulse;
    }


    /// <summary>
    /// Register hit and push attacker
    /// </summary>
    public void OnCollision(ICharacter self, ICharacter other)
    {
        EventQueueLocator.service.EnqueueOnEntityHit(self.playerIndex, other.playerIndex);
        PushSelf(self, other);
    }



    private void PushSelf(ICharacter self, ICharacter other)
    {
        var pushDirection = self.position.value - other.position.value;
        self.movement.AddImpulse(pushDirection, pushImpulse);
    }
}
