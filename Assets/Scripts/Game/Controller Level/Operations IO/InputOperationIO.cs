using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOperationIO : IInputOperationIO
{
    public int playersAmount => playerOperations.Count;
    public PlayerOperationData[] players => playerOperations.ToArray();

    public PlayerControlParameters controlParameters => gameData.controlParameters;

    private List<PlayerOperationData> playerOperations = new List<PlayerOperationData>();
    private GameData gameData;


    public InputOperationIO(GameData gameData)
    {
        this.gameData = gameData;
    }


    public void Refresh()
    {
        GetPlayerOperations();
    }



    private PlayerOperationData[] GetPlayerOperations()
    {
        //Combine inputs and characters using NetID
        var players = PlayerManagementLocator.service.allPlayers;

        playerOperations.Clear();

        foreach (var player in players)
            if (CharacterStorageLocator.service.TryGetCharacter(player.playerIndex, out var character))
                playerOperations.Add(new PlayerOperationData() { character = character, input = player.gameInput });

        return playerOperations.ToArray();
    }
}
