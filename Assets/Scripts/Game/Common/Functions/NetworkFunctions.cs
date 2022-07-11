using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public static class NetworkFunctions
{
    private static NetworkRoomManager room => NetworkManager.singleton as NetworkRoomManager;


    public static void StartGame() => room.ServerChangeScene(room.GameplayScene);

    public static void SetNetAddress(string value) => NetworkManager.singleton.networkAddress = value;

    public static void StartHost() => NetworkManager.singleton.StartHost();
    public static void StartServer() => NetworkManager.singleton.StartServer();

    public static void ConnectToRoom() => NetworkManager.singleton.StartClient();
    public static void ReturnToRoom() => room.ServerChangeScene(room.RoomScene);

    public static void Disconnect()
    {
        // stop host if host mode
        if (NetworkServer.active && NetworkClient.isConnected)
            NetworkManager.singleton.StopHost();

        // stop client if client-only
        else if (NetworkClient.isConnected)
            NetworkManager.singleton.StopClient();

        // stop server if server-only
        else if (NetworkServer.active)
            NetworkManager.singleton.StopServer();
    }


    public static NetworkConnectionToClient[] GetConnections()
    {
        return NetworkServer.connections.Values.ToArray();
    }

    public static Transform GetSpawnPosition()
    {
        return room.GetStartPosition();
    }

    public static NetworkRoomPlayer GetPlayer(int connID)
    {
        var room = NetworkManager.singleton as NetworkRoomManager;
        Debug.Log($"Room slots occupied {room.roomSlots.Count}");

        foreach (var player in room.roomSlots)
            if (player.connectionToClient.connectionId == connID)
                return player;

        throw new System.Exception($"Player {connID} not found!");
    }
}
