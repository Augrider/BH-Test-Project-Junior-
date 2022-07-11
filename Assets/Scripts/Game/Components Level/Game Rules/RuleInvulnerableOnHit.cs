using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleInvulnerableOnHit : IPlayerInteractionGameRule
{
    public void ApplyRule(IRulesIO rulesIO, int actorIndex, params int[] receiversIndex)
    {
        //Add score to hitter
        rulesIO.gameState.AddScore(actorIndex, 1);

        //Enable invulnerability
        foreach (var receiver in receiversIndex)
            SetHitState(rulesIO, receiver);
    }



    private void SetHitState(IRulesIO rulesIO, int hitPlayerIndex)
    {
        var hitCharacter = CharacterStorageLocator.service.GetCharacter(hitPlayerIndex);
        var defaultColor = PlayerManagementLocator.service.GetPlayer(hitPlayerIndex).playerColor;

        CoroutineObjectLocator.service.StartCoroutine(WaitInHitState(hitCharacter, defaultColor, rulesIO.gameData.colorPalette.hitStateColor, rulesIO.gameData.hitStateDuration));
    }

    /// <summary>
    /// Set character to be invulnerable in hit state for a duration
    /// </summary>
    private IEnumerator WaitInHitState(ICharacter character, Color playerColor, Color hitColor, float duration)
    {
        character.state.invulnerable = true;

        character.color.SetColor(hitColor);
        yield return new WaitForSeconds(duration);

        character.color.SetColor(playerColor);
        character.state.invulnerable = false;
    }
}
