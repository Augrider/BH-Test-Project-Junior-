using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterData : ScriptableObject, IEntitySpawnProvider
{
    [Tooltip("Reference to prefab used as an object in game")]
    [SerializeField] protected GameObject gameObjectPrefab;
    public GameObject prefab => gameObjectPrefab;


    /// <summary>
    /// Initialize components for provided Character GameObject
    /// </summary>
    /// <param name="spawnedObject">Character GameObject</param>
    /// <param name="playerIndex">Index of player owner</param>
    /// <param name="position">Spawn position</param>
    /// <param name="direction">Spawn Direction</param>
    /// <returns>Character interface</returns>
    public ICharacter InitializeCharacter(GameObject spawnedObject, int playerIndex, Vector3 position, Vector3 direction)
    {
        if (!spawnedObject.TryGetComponent<Character>(out var entity))
            throw new System.Exception();

        entity.playerIndex = playerIndex;

        var builder = new CharacterConstructor(entity);
        BuildEntityComponents(builder, spawnedObject, position, direction);

        return entity;
    }

    /// <summary>
    /// Initialize components for provided builder
    /// </summary>
    /// <param name="builder">Builder for character object</param>
    /// <param name="charObject">Character GameObject</param>
    /// <param name="position">Spawn position</param>
    /// <param name="direction">Spawn Direction</param>
    public abstract void BuildEntityComponents(ICharacterConstructor builder, GameObject charObject, Vector3 position, Vector3 direction);
}
