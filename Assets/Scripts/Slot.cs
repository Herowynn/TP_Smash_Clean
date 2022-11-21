using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image CharacterPicture;
    public TextMeshProUGUI CharacterName;
    public Image Logo;
    private float _initialPositionX = 5f;

    public void SetCharacterSprite(CharacterUI characterUI)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(CharacterPicture.transform.DOLocalMoveX(-100 + _initialPositionX, 0.1f));
        sequence.AppendCallback(() =>
        {
            CharacterPicture.sprite = characterUI.Picture.sprite;
            Logo.sprite = characterUI.Logo;
            CharacterPicture.GetComponent<RectTransform>().pivot = characterUI.Picture.GetComponent<RectTransform>().pivot;
            CharacterPicture.GetComponent<RectTransform>().sizeDelta = characterUI.Picture.GetComponent<RectTransform>().sizeDelta;
        });
        sequence.Append(CharacterPicture.transform.DOLocalMoveX(100 + _initialPositionX, 0));
        sequence.Append(CharacterPicture.transform.DOLocalMoveX( + _initialPositionX, 0.2f));
        CharacterName.text = characterUI.TextName.text;
    }
}
