using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPool : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (DragHandler.itemBeingDraged == null) return;
        DragHandler.itemBeingDraged.transform.SetParent(transform);
    }

}
