using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntitySpawnProvider
{
    GameObject prefab { get; }

    /// <summary>
    /// Set all components on spawned gameObject's Character component and return interface
    /// </summary>
    ICharacter InitializeCharacter(GameObject spawnedObject, int playerIndex, Vector3 position, Vector3 direction);
}