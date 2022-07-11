using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterStorage
{
    /// <summary>
    /// Get characters stored on client
    /// </summary>
    ICharacter[] GetAllCharacters();

    ICharacter GetCharacter(int playerIndex);
    bool TryGetCharacter(int playerIndex, out ICharacter character);

    /// <summary>
    /// Create character on client
    /// </summary>
    /// <remarks>
    /// Created character won't be spawned in this function
    /// </remarks>
    (GameObject, ICharacter) CreateCharacter(int playerIndex, Vector3 position, Vector3 direction);

    /// <summary>
    /// Provide client with correct client side GameObject/ICharacter pair
    /// </summary>
    void ProvideCharacter(int playerIndex, GameObject charObject, ICharacter character);

    /// <summary>
    /// Remove character on client side
    /// </summary>
    void RemoveCharacter(int playerIndex);

    /// <summary>
    /// Remove all characters on client side
    /// </summary>
    void Clear();
}