using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

internal class Character : NetworkBehaviour, ICharacter, IPositionProvider, IDirectionProvider, IColorProvider
{
    //Note: Network Behaviors are the only ones capable of using SyncVar
    //For that reason object state should be kept either inside main behavior script or separate NetworkBehavior
    //For data consistency and to avoid Rpc calls without network we should do hook on target object, then set SyncVar parameters.
    //They, in turn, will invoke hook on all copies of object

    public int playerIndex { get => state.playerIndex; set => state.playerIndex = value; }

    public IPositionProvider position => this;
    public IDirectionProvider direction => this;
    public IColorProvider color => this;

    public ICharacterState state => characterState;

    public IMovement movement { get; internal set; }
    public IInteractions interactions { get; internal set; }
    public IAbility ability { get; internal set; }

    Vector3 IPositionProvider.value => transform.position;
    Vector3 IDirectionProvider.forward => directionTransform.forward;
    Color IColorProvider.value => modelRenderer.material.color;

    [SerializeField] private Transform directionTransform;
    [SerializeField] private Renderer modelRenderer;
    [SerializeField] private CharacterState characterState;


    public void SetPosition(Vector3 value)
    {
        transform.position = value;
        SetPositionRpc(value);
    }

    public void SetDirection(Vector3 value)
    {
        directionTransform.forward = value;
        SetDirectionRpc(value);
    }

    public void SetColor(Color value)
    {
        modelRenderer.material.color = value;
        SetColorRpc(value);
    }



    [ClientRpc]
    private void SetPositionRpc(Vector3 value) => transform.position = value;

    [ClientRpc]
    private void SetDirectionRpc(Vector3 value) => directionTransform.forward = value;

    [ClientRpc]
    private void SetColorRpc(Color value) => modelRenderer.material.color = value;
}
