using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class TriggerComponent : CharacterNetworkComponent, ITriggerComponent
{
    [SerializeField] private Collider triggerCollider;

    public event System.Action<ICharacter, ICharacter> OnTriggerDetected;


    protected override void Start()
    {
        base.Start();

        if (isServer)
            StartCoroutine(WaitAndSync());
    }


    [Command(requiresAuthority = false)]
    public void CmdToggleActive(bool value) => RpcToggleActive(value);

    [Server]
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Character>(out var character) && (ICharacter)character != ownCharacter)
            OnTriggerDetected?.Invoke(ownCharacter, character);
    }


    [ClientRpc]
    private void RpcToggleActive(bool value)
    {
        triggerCollider.enabled = value;
    }


    private IEnumerator WaitAndSync()
    {
        yield return null;

        RpcToggleActive(false);
    }
}
