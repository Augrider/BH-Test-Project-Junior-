using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Dash")]
public class DashAbility : BaseAbilityData
{
    public float distance;
    public float duration;


    public override IEnumerator AbilityEffect(ICharacter self, Vector3 direction)
    {
        var direction2d = direction;
        direction2d.y = 0;
        direction2d = direction2d.normalized;

        var speed = (distance / duration) * direction2d;
        var timeLeft = duration;

        OnAbilityStart(self);

        while (timeLeft > 0)
        {
            self.movement.SetSpeed(speed);
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        OnAbilityEnd(self);
    }


    public void OnAbilityStart(ICharacter self)
    {
        self.state.lockPositionControl = true;
        self.state.lockDirectionControl = true;

        self.interactions.trigger.CmdToggleActive(true);
        self.interactions.trigger.OnTriggerDetected += OnCollision;
    }

    public void OnAbilityEnd(ICharacter self)
    {
        self.state.lockPositionControl = false;
        self.state.lockDirectionControl = false;

        self.interactions.trigger.CmdToggleActive(false);
        self.interactions.trigger.OnTriggerDetected -= OnCollision;
    }


    public void OnCollision(ICharacter self, ICharacter other)
    {
        if (!other.state.invulnerable)
            other.interactions.OnCollision(other, self);
    }
}