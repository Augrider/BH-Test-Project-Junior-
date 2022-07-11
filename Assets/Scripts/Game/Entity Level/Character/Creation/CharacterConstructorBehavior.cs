using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component calls initialization of components on character using provided data
/// </summary>
internal class CharacterConstructorBehavior : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private CharacterData characterData;


    void Awake()
    {
        var builder = new CharacterConstructor(character);
        characterData.BuildEntityComponents(builder, gameObject, character.position.value, character.direction.forward);

        Destroy(this);
    }
}
