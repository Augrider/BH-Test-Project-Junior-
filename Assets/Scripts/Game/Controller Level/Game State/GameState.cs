using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameState : NetworkBehaviour, IGameState
{
    [SerializeField] private GameScore gameScore;
    [SerializeField] private GameLoop gameLoop;


    [Server]
    void Start()
    {
        foreach (var playerData in PlayerManagementLocator.service.allPlayers)
            gameScore.AddPlayer(playerData.playerIndex, 0);
    }


    [Server]
    public void StartGame()
    {
        Debug.Log("Game Started!");

        RpcRefreshUI(GetAllScoreRecords());

        GameUILocator.service.OnStartGame(() => gameLoop.enabled = true);
        RpcOnGameStart();
    }

    [Server]
    public void EndGame(ScoreRecord[] winners)
    {
        Debug.Log("Game Ended!");

        GameUILocator.service.OnGameOver(winners, OnGameOver);
        RpcOnGameOver(winners);
    }


    public int GetScore(int playerIndex) => gameScore.GetScore(playerIndex);
    public ScoreRecord[] GetAllScoreRecords() => gameScore.GetAllScoreRecords();


    [Server]
    public void SetScore(int playerIndex, int score)
    {
        gameScore.SetScore(playerIndex, score);
        RpcRefreshUI(GetAllScoreRecords());
    }

    [Server]
    public void AddScore(int playerIndex, int score)
    {
        gameScore.AddScore(playerIndex, score);
        Debug.Log("Score added");
        RpcRefreshUI(GetAllScoreRecords());
    }



    [ClientRpc]
    private void RpcRefreshUI(ScoreRecord[] scoreRecords) => GameUILocator.service.RefreshScore(scoreRecords);

    [ClientRpc]
    private void RpcOnGameStart()
    {
        if (!isServer)
            GameUILocator.service.OnStartGame();
    }

    [ClientRpc]
    private void RpcOnGameOver(ScoreRecord[] winners)
    {
        if (!isServer)
            GameUILocator.service.OnGameOver(winners);
    }


    private void OnGameOver()
    {
        PlayerManagementLocator.service.ResetInput();

        //Reload game
        NetworkFunctions.StartGame();
    }
}
