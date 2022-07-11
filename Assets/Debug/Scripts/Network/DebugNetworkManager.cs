using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class DebugNetworkManager : NetworkManager
{
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        Debug.Log($"Client {conn.connectionId} connected to server, OSC fired");

        PlayerManagementLocator.service.AddPlayer(conn.connectionId);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log($"Client {conn.connectionId} disconnected, OSD fired");

        CharacterStorageLocator.service.RemoveCharacter(conn.connectionId);
        PlayerManagementLocator.service.RemovePlayer(conn.connectionId);

        base.OnServerDisconnect(conn);
    }


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        var playerObject = BaseCreatePlayer(conn);
        DebugPlayer player = playerObject.GetComponent<DebugPlayer>();

        Debug.Log($"Setting index for {conn.connectionId}");
        player.SetPlayerIndex(conn.connectionId);

        var playerColor = PlayerManagementLocator.service.GetPlayer(conn.connectionId).playerColor;
        CreateCharacter(conn, playerObject.transform, playerColor);
    }



    private GameObject BaseCreatePlayer(NetworkConnectionToClient conn)
    {
        Transform startPos = GetStartPosition();
        GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab);

        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, player);

        return player;
    }


    private static void CreateCharacter(NetworkConnectionToClient conn, Transform spawnTransform, Color playerColor)
    {
        (var charObject, var character) = CharacterStorageLocator.service.CreateCharacter(conn.connectionId, spawnTransform.position, spawnTransform.forward);

        NetworkServer.Spawn(charObject, conn);
        character.color.SetColor(playerColor);
    }
}
