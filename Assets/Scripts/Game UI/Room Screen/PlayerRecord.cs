using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mirror;

public class PlayerRecord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private Graphic playerColorGraphic;
    [SerializeField] private Toggle toggle;

    [SerializeField] private RoomScreen roomScreen;

    public bool isReady { get; private set; }
    private int playerIndex;


    void Awake()
    {
        toggle.onValueChanged.AddListener(ToggleReady);
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(ToggleReady);
    }


    public void SetRecord(PlayerData playerData, bool readyState, bool isLocalPlayer)
    {
        this.playerIndex = playerData.playerIndex;
        this.isReady = readyState;

        toggle.SetIsOnWithoutNotify(readyState);
        toggle.interactable = isLocalPlayer;

        nameField.SetText(playerData.playerName);
        playerColorGraphic.color = playerData.playerColor;
    }

    public void ResetRecord()
    {
        this.isReady = true;

        toggle.SetIsOnWithoutNotify(false);
        toggle.interactable = false;

        nameField.SetText("Open");
        playerColorGraphic.color = Color.gray;
    }


    public void ToggleReady(bool value)
    {
        Debug.Log("Toggle pressed!");

        roomScreen.CmdToggleReadyState(playerIndex, value);
    }
}
