using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class GameRoomManager : NetworkRoomManager
{
    [Scene]
    public string GameUIScene;


    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);

        Debug.Log($"Client {conn.connectionId} connected to server, OSC fired");

        PlayerManagementLocator.service.AddPlayer(conn.connectionId);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log($"Client {conn.connectionId} disconnected, OSD fired");

        PlayerManagementLocator.service.RemovePlayer(conn.connectionId);

        try
        {
            CharacterStorageLocator.service.RemoveCharacter(conn.connectionId);
        }
        finally
        {
            base.OnServerDisconnect(conn);
        }
    }


    public override void OnClientSceneChanged()
    {
        base.OnClientSceneChanged();

        if (IsSceneActive(GameplayScene))
            StartCoroutine(LoadUI());
    }



    IEnumerator LoadUI()
    {
        Debug.Log("Loading UI");

        yield return SceneManager.LoadSceneAsync(GameUIScene, LoadSceneMode.Additive);
    }
}
