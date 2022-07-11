using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullCharacterStorage : ICharacterStorage
{
    public bool TryGetCharacter(uint playerNetID, out ICharacter character)
    {
        character = null;
        return false;
    }



    public (GameObject, ICharacter) CreateCharacter(int playerIndex, Vector3 position, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public ICharacter[] GetAllCharacters()
    {
        throw new System.NotImplementedException();
    }

    public ICharacter GetCharacter(int playerIndex)
    {
        throw new System.NotImplementedException();
    }

    public void ProvideCharacter(int playerIndex, GameObject charObject, ICharacter character)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveCharacter(int playerIndex) { }

    public void Clear() { }

    public bool TryGetCharacter(int playerIndex, out ICharacter character)
    {
        throw new System.NotImplementedException();
    }
}
