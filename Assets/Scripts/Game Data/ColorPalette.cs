using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Color Palette")]
public class ColorPalette : ScriptableObject
{
    public Color hitStateColor;
    public Color[] playerColors;

    public Color GetPlayerColor(int index)
    {
        if (playerColors.Length <= index)
            return Color.gray;

        return playerColors[index];
    }
}
