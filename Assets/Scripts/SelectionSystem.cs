using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionSystem : MonoBehaviour
{
    public GraphicRaycaster GraphicRaycaster;
    public Color SelectedColor = Color.white;
    private CharacterUI _selectedCharacter;
    public List<GameObject> Slots = new List<GameObject>();
    public Texture2D MouseCursor;
    public Image Logo;

    private void Start()
    {
        Cursor.SetCursor(MouseCursor, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        PointerEventData eventData = new PointerEventData(null);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();

        GraphicRaycaster.Raycast(eventData, raycastResults);

        if(raycastResults.Count > 1)
        {
            foreach (var item in raycastResults)
            {
                CharacterUI characterUI;
                if (item.gameObject.TryGetComponent<CharacterUI>(out characterUI))
                {
                    int rand = Random.Range(0, 4);
                    if (_selectedCharacter != null && _selectedCharacter != characterUI)
                    {
                        _selectedCharacter.SelectionBorder.DOFade(0, 0.1f);
                    }

                    characterUI.SelectionBorder.DOFade(1, 0.1f);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Slots[rand].GetComponent<Slot>().SetCharacterSprite(characterUI);
                    }
                        
                    _selectedCharacter = characterUI;

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (_selectedCharacter != null)
                        {
                            Slots[rand].transform.DOPunchPosition(Vector3.down, 0.25f, 2, 0);
                        }
                    }
                    break;
                }
            }
        }
    }
}
