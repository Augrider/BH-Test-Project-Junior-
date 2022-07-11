using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;

public class DefaultCharacterStorage : MonoBehaviour, ICharacterStorage
{
    //Note to self: if we will have multiple choices for characters to spawn we can create library and use some kind of library identifiers
    //We will need to check for libraries to be the same both on server and clients, but that can be handled by Addressables

    private Dictionary<int, CharacterRecord> clientCharacters = new Dictionary<int, CharacterRecord>();

    [SerializeField] private Transform parent;
    [SerializeField] private GameData gameData;


    void Awake()
    {
        CharacterStorageLocator.Provide(this);
    }

    void OnDestroy()
    {
        CharacterStorageLocator.Provide(null);
    }


    public ICharacter[] GetAllCharacters()
    {
        return clientCharacters.Values.Select(t => t.character).ToArray();
    }


    public ICharacter GetCharacter(int playerIndex)
    {
        if (!clientCharacters.ContainsKey(playerIndex))
            throw new System.Exception();

        return clientCharacters[playerIndex].character;
    }

    public bool TryGetCharacter(int playerIndex, out ICharacter character)
    {
        character = null;

        if (!clientCharacters.ContainsKey(playerIndex))
            return false;

        character = clientCharacters[playerIndex].character;
        return true;
    }


    //TODO: Destroy previous record object?
    public void ProvideCharacter(int playerIndex, GameObject charObject, ICharacter character)
    {
        if (clientCharacters.ContainsKey(playerIndex))
        {
            clientCharacters[playerIndex] = new CharacterRecord(character, charObject);
            return;
        }

        clientCharacters.Add(playerIndex, new CharacterRecord(character, charObject));
    }


    public (GameObject, ICharacter) CreateCharacter(int playerIndex, Vector3 position, Vector3 direction)
    {
        if (clientCharacters.ContainsKey(playerIndex))
            throw new System.Exception("Character with provided player index already exists!");

        var charObject = Instantiate(gameData.playerCharacterData.prefab, parent);

        charObject.transform.position = position;
        charObject.transform.forward = direction;

        var character = gameData.playerCharacterData.InitializeCharacter(charObject, playerIndex, position, direction);
        clientCharacters.Add(playerIndex, new CharacterRecord(character, charObject));

        return (charObject, character);
    }

    public void RemoveCharacter(int playerIndex)
    {
        if (!clientCharacters.ContainsKey(playerIndex))
            return;

        Destroy(clientCharacters[playerIndex].charObject);
        clientCharacters.Remove(playerIndex);
    }


    public void Clear()
    {
        foreach (var charData in clientCharacters.Values)
            Destroy(charData.charObject);

        clientCharacters.Clear();
    }



    private readonly struct CharacterRecord
    {
        public readonly ICharacter character;
        public readonly GameObject charObject;

        public CharacterRecord(ICharacter character, GameObject charObject)
        {
            this.character = character;
            this.charObject = charObject;
        }
    }
}
