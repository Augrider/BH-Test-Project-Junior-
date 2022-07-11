using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DebugPlayer : NetworkBehaviour
{
    [SyncVar]
    private int playerIndex;


    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        StartCoroutine(WaitAndInitializeInput(playerIndex));
    }

    public override void OnStopLocalPlayer()
    {
        base.OnStopLocalPlayer();

        if (!isLocalPlayer)
            return;

        Reset();

        Debug.Log($"Player {playerIndex} stopped");
    }


    [Server]
    public void SetPlayerIndex(int playerIndex)
    {
        this.playerIndex = playerIndex;
        RpcOnSetIndex(playerIndex);
    }



    //Note to self: validation of input usually happens in command (CmdSetInput)
    [Command]
    private void CmdSetInput(GameInput input) => PlayerManagementLocator.service.UpdateInput(playerIndex, input);


    [TargetRpc]
    private void RpcOnSetIndex(int playerIndex)
    {
        // if (!isLocalPlayer)
        //     return;

        StartCoroutine(WaitAndInitializeInput(playerIndex));
    }


    private IEnumerator WaitAndInitializeInput(int playerIndex)
    {
        ICharacter character;

        while (!CharacterStorageLocator.service.TryGetCharacter(playerIndex, out character))
            yield return null;

        Debug.Log($"Player {playerIndex} init input");

        InputLocator.service.CameraFollowObject(character.position);
        InputLocator.service.OnInputChanged += CmdSetInput;
    }

    private void Reset()
    {
        CharacterStorageLocator.service.Clear();

        InputLocator.service.CameraFollowObject(null);
        InputLocator.service.OnInputChanged -= CmdSetInput;
    }
}