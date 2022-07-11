using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters/Basic Character")]
public class GameCharacterData : CharacterData
{
    [SerializeField] private BaseAbilityData abilityData;
    [SerializeField] private float pushOnHitImpulse;


    public override void BuildEntityComponents(ICharacterConstructor builder, GameObject clone, Vector3 position, Vector3 direction)
    {
        if (!clone.TryGetComponent<Rigidbody>(out var rigidbody))
            throw new System.Exception();

        if (!clone.TryGetComponent<TriggerComponent>(out var trigger))
            throw new System.Exception();

        builder.ProvideMovement(new DefaultMovement(rigidbody));
        builder.ProvideInteractions(new DefaultInteractions(trigger, pushOnHitImpulse));
        builder.ProvideAbility(new AbilityState(abilityData));
    }
}
