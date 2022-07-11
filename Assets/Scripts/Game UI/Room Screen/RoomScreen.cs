using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;

public class RoomScreen : NetworkBehaviour
{
    [SerializeField] private PlayerRecord[] playerRecords;
    [SerializeField] private GameObject startGameButton;

    [SerializeField] private float refreshDelay = 0.1f;

    [SerializeField] private int minPlayers = 2;
    private int playersCount;


    void Start()
    {
        PlayerManagementLocator.service.PlayerChanged += CmdOnPlayerChanged;

        //TODO: Change this for less hacky solution
        CmdOnPlayerChanged(0);
    }

    void OnDestroy()
    {
        PlayerManagementLocator.service.PlayerChanged -= CmdOnPlayerChanged;
    }


    public void ReturnToMenu() => NetworkFunctions.Disconnect();

    public void StartGame()
    {
        if (!ReadyToStart())
            return;

        NetworkFunctions.StartGame();
    }


    [Command(requiresAuthority = false)]
    public void CmdOnPlayerChanged(int playerIndex)
    {
        StartCoroutine(WaitAndRefresh());
    }

    [Command(requiresAuthority = false)]
    public void CmdToggleReadyState(int playerIndex, bool value)
    {
        var player = NetworkFunctions.GetPlayer(playerIndex);
        player.readyToBegin = value;

        StartCoroutine(WaitAndRefresh());
    }



    private IEnumerator WaitAndRefresh()
    {
        yield return new WaitForSeconds(refreshDelay);

        RpcRefreshAll();

        yield return null;

        if (isServer)
            startGameButton.SetActive(ReadyToStart());
    }


    private void RpcRefreshAll()
    {
        playersCount = PlayerManagementLocator.service.playerCount;
        var players = PlayerManagementLocator.service.allPlayers;

        for (int i = 0; i < playerRecords.Length; i++)
        {
            if (i >= playersCount)
            {
                RpcResetPlayerData(i);
                continue;
            }

            var player = NetworkFunctions.GetPlayer(players[i].playerIndex);
            RpcSetPlayerData(players[i], i, player.readyToBegin, player);
        }
    }


    [ClientRpc]
    private void RpcSetPlayerData(PlayerData playerData, int slotIndex, bool readyState, NetworkRoomPlayer player)
    {
        playerRecords[slotIndex].SetRecord(playerData, readyState, player.isLocalPlayer);
    }

    [ClientRpc]
    private void RpcResetPlayerData(int slotIndex)
    {
        playerRecords[slotIndex].ResetRecord();
    }


    private bool ReadyToStart()
    {
        return playerRecords.All(t => t.isReady) && (playersCount >= minPlayers || minPlayers < 1);
    }
}
