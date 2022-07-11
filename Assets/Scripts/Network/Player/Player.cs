using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Player : NetworkBehaviour
{
    [SyncVar]
    private int playerIndex;

    [SerializeField] private float inputInitDelay = 0.1f;


    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        CmdRefreshIndex();
    }

    public override void OnStopLocalPlayer()
    {
        ResetInput();
        base.OnStopLocalPlayer();
    }



    [Command]
    private void CmdRefreshIndex()
    {
        RpcRefreshIndex(connectionToClient.connectionId);
    }

    [TargetRpc]
    private void RpcRefreshIndex(int playerIndex)
    {
        Debug.LogFormat("Got index {0}", playerIndex);
        this.playerIndex = playerIndex;

        StartCoroutine(WaitAndInitializeInput(playerIndex));
    }


    private void OnInputChanged(GameInput input) => CmdSetInput(playerIndex, input);

    //Note: validation of input usually happens in command (CmdSetInput)
    [Command]
    private void CmdSetInput(int playerIndex, GameInput input) => PlayerManagementLocator.service.UpdateInput(playerIndex, input);


    private IEnumerator WaitAndInitializeInput(int playerIndex)
    {
        yield return new WaitForSeconds(inputInitDelay);

        ICharacter character;

        while (!CharacterStorageLocator.service.TryGetCharacter(playerIndex, out character))
            yield return null;

        Debug.Log($"Player {playerIndex} init input");

        InputLocator.service.CameraFollowObject(character.position, character.direction.forward);
        InputLocator.service.OnInputChanged += OnInputChanged;
    }

    private void ResetInput()
    {
        InputLocator.service.CameraFollowObject(null);
        InputLocator.service.OnInputChanged -= OnInputChanged;

        Debug.Log($"Player {playerIndex} stopped input");
    }
}