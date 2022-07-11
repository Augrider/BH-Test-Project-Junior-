using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuScreen : MonoBehaviour
{
    // [SerializeField] private TextMeshProUGUI roomIdInput;


    public void SetRoomID(string value) => NetworkFunctions.SetNetAddress(value);

    public void StartHost() => NetworkFunctions.StartHost();
    public void ConnectToRoom() => NetworkFunctions.ConnectToRoom();
    public void QuitGame() => Application.Quit();
}