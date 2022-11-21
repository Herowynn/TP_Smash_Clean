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
            characterGO.GetComponentsInChildren<Image>()[1].sprite = character.Picture;
            characterGO.GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>().pivot = character.Offset;
            //characterGO.GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>().sizeDelta = character.Size;
            characterGO.GetComponentInChildren<TextMeshProUGUI>().text = character.Name;

        }
    }
}
