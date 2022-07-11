using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CharacterConstructor : ICharacterConstructor
{
    private Character character;


    public CharacterConstructor(Character character)
    {
        this.character = character;
    }


    public void ProvideMovement(IMovement value) => this.character.movement = value;
    public void ProvideInteractions(IInteractions value) => this.character.interactions = value;
    public void ProvideAbility(IAbility value) => this.character.ability = value;
}