using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Game Data Collection")]
public class GameData : ScriptableObject
{
    [Tooltip("Character data, shared between players")]
    public CharacterData playerCharacterData;

    [Tooltip("Color palette for coloring characters")]
    public ColorPalette colorPalette;

    [Tooltip("Parameters for character control (acceleration and rotation speed)")]
    public PlayerControlParameters controlParameters;

    [Tooltip("Specifies for how much time character stays invulnerable after getting hit")]
    public float hitStateDuration;

    [Tooltip("Specifies how much points player should get in order to win the game")]
    public int winScore;
}