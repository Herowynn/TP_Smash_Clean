using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionSystem : MonoBehaviour
{
    public GraphicRaycaster GraphicRaycaster;
    public Color SelectedColor = Color.white;
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
                    characterUI.SelectionBorder.color = SelectedColor;
                    break;
                }
            }
        }
    }
}
