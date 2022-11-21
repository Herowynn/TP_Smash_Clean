using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersGrid : MonoBehaviour
{
    public GameObject PrefabCharacter;
    [Range(1, 18)] public int NumberOfCharacter = 1;
    public List<CharacterData> Characters;

    void Start()
    {
        Characters = new List<CharacterData>();

        for (int i = 0; i < NumberOfCharacter; i++)
        {
            GameObject character = GameObject.Instantiate(PrefabCharacter, transform);
        }
    }
}
