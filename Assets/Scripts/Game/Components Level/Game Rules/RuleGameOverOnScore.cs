using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RuleGameOverOnScore : IGameRule
{
    public bool CheckCondition(IRulesIO rulesIO)
    {
        //Check if someone got enough points
        return PlayerManagementLocator.service.allPlayers.Any(t => rulesIO.gameState.GetScore(t.playerIndex) >= rulesIO.gameData.winScore);
    }

    public void ApplyRule(IRulesIO rulesIO)
    {
        //Find winner and proceed to game end
        ScoreRecord[] winners = GetWinners(rulesIO.gameState, rulesIO.gameData.winScore);

        rulesIO.gameLoopControl.enabled = false;
        rulesIO.gameState.EndGame(winners);
    }



    private ScoreRecord[] GetWinners(IGameState gameState, int winScore)
    {
        var scores = gameState.GetAllScoreRecords();
        var winners = scores.Where(t => t.playerScore >= winScore);

        return winners.ToArray();
    }
}
