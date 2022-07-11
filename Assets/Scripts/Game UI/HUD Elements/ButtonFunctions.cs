using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void Disconnect()
    {
        NetworkFunctions.Disconnect();
    }

    public void ToRoom()
    {
        NetworkFunctions.ReturnToRoom();
    }
}
