using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGrid : MonoBehaviour
{
    public GameObject CharacterPrefab;
    private int NumberOfCharacters;
    public List<CharacterData> Characters = new List<CharacterData>();

    private void Start()
    {
        NumberOfCharacters =  Characters.Count;

        foreach (var character in Characters)
        {
            GameObject characterGO = Instantiate(CharacterPrefab, transform);
            CharacterUI characterUI = characterGO.GetComponent<CharacterUI>();
            characterUI.Picture.sprite = character.Picture;
            characterUI.Picture.GetComponent<RectTransform>().pivot = character.Offset;
            characterUI.Logo = character.Logo;
            //characterUI.Picture.GetComponent<RectTransform>().sizeDelta = character.Size;
            characterUI.TextName.text = character.Name;

        }
    }
}
