using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for common game rules
/// </summary>
public interface IGameRule
{
    bool CheckCondition(IRulesIO rulesIO);
    void ApplyRule(IRulesIO rulesIO);
}


/// <summary>
/// Interface for handling specific rules for player interactions
/// </summary>
public interface IPlayerInteractionGameRule
{
    void ApplyRule(IRulesIO rulesIO, int actorIndex, params int[] receiversIndex);
}
