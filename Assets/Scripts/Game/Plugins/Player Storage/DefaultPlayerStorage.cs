using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Linq;
using System;

public class DefaultPlayerStorage : MonoBehaviour, IPlayerManagement
{
    private Dictionary<int, PlayerData> players = new Dictionary<int, PlayerData>();

    public PlayerData[] allPlayers => players.Values.ToArray();
    public int playerCount => players.Count;

    public int localPlayerIndex { get; set; }

    public event Action<int> PlayerChanged;

    [SerializeField] private GameData gameData;


    void Awake()
    {
        PlayerManagementLocator.Provide(this);
    }

    void OnDestroy()
    {
        PlayerManagementLocator.Provide(null);
    }


    public PlayerData GetPlayer(int playerIndex)
    {
        if (!players.ContainsKey(playerIndex))
            throw new System.Exception();

        return players[playerIndex];
    }


    public void AddPlayer(int playerIndex)
    {
        if (players.ContainsKey(playerIndex))
            return;

        AddPlayerToStorage(playerIndex);
        PlayerChanged?.Invoke(playerIndex);
    }

    public void RemovePlayer(int playerIndex)
    {
        if (!players.ContainsKey(playerIndex))
            return;

        RemovePlayerFromStorage(playerIndex);
        PlayerChanged?.Invoke(playerIndex);
    }


    public void ChangeName(int playerIndex, string value)
    {
        if (!players.ContainsKey(playerIndex))
            throw new System.Exception();

        var data = players[playerIndex];
        data.playerName = value;

        players[playerIndex] = data;
        PlayerChanged?.Invoke(playerIndex);
    }

    public void ChangeColor(int playerIndex, Color value)
    {
        if (!players.ContainsKey(playerIndex))
            throw new System.Exception();

        var data = players[playerIndex];
        data.playerColor = value;

        players[playerIndex] = data;
        PlayerChanged?.Invoke(playerIndex);
    }


    public void UpdateInput(int playerIndex, GameInput input)
    {
        if (!players.ContainsKey(playerIndex))
            throw new System.Exception();

        var temp = players[playerIndex];
        temp.gameInput = input;

        players[playerIndex] = temp;
    }


    public void ResetInput()
    {
        foreach (var playerIndex in players.Keys.ToArray())
        {
            var temp = players[playerIndex];

            temp.gameInput = new GameInput();

            players[playerIndex] = temp;
        }
    }



    private void AddPlayerToStorage(int playerIndex)
    {
        var data = new PlayerData();

        data.playerIndex = playerIndex;
        data.playerName = $"Player [{playerIndex % 1000}]";
        data.playerColor = gameData.colorPalette.GetPlayerColor(playerCount);

        players.Add(playerIndex, data);
    }

    private void RemovePlayerFromStorage(int playerIndex)
    {
        players.Remove(playerIndex);
    }
}
