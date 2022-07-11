using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains Ability Data and provides ability interface
/// </summary>
/// <remarks>
/// While it's called state, in reality it only works with provided character state.
/// Abilities and this class are not allowed to have their own state
/// </remarks>
public class AbilityState : IAbility
{
    private BaseAbilityData ability;


    public AbilityState(BaseAbilityData ability)
    {
        this.ability = ability;
    }


    public void Invoke(ICharacter self, Vector3 direction)
    {
        if (self.state.abilityOnCooldown)
            return;

        CoroutineObjectLocator.service.StartCoroutine(ProcessAbility(self, direction));
    }



    private IEnumerator ProcessAbility(ICharacter self, Vector3 direction)
    {
        self.state.abilityOnCooldown = true;

        yield return ability.AbilityEffect(self, direction);

        yield return new WaitForSeconds(ability.cooldown);
        self.state.abilityOnCooldown = false;
    }
}
