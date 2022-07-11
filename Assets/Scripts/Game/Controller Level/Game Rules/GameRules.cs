using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameRules : MonoBehaviour, IRulesIO
{
    public IGameRule ruleGameOverOnScore { get; set; }
    public IPlayerInteractionGameRule ruleOnHit { get; set; }

    IGameState IRulesIO.gameState => gameState;
    GameData IRulesIO.gameData => gameData;
    IGameLoopControl IRulesIO.gameLoopControl => gameLoop;

    [SerializeField] private GameData gameData;
    [SerializeField] private GameState gameState;
    [SerializeField] private GameLoop gameLoop;


    void Start()
    {
        EventQueueLocator.service.OnEntityHit += OnEntityHit;
    }

    void OnDestroy()
    {
        EventQueueLocator.service.OnEntityHit -= OnEntityHit;
    }



    [Server]
    private void OnEntityHit(int hitPlayerIndex, int hitterPlayerIndex)
    {
        ruleOnHit.ApplyRule(this, hitterPlayerIndex, hitPlayerIndex);

        if (ruleGameOverOnScore.CheckCondition(this))
            ruleGameOverOnScore.ApplyRule(this);
    }
}
