using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public static GameObject itemBeingDraged;
    public static ItemInfo tmInfo;
    ItemInfo dropInfo;
    private Vector2 currentPosition;
    RectTransform TargetTransform;
    private bool isDrag;

    private void Start() 
    {
        TargetTransform = GetComponent<RectTransform>();
        isDrag = true;
    }

    #region DragFunctions

    public void OnBeginDrag(PointerEventData eventData)
    {

            GameObject duplicate = Instantiate(gameObject);

            itemBeingDraged = duplicate;
            RectTransform tmpRT = gameObject.GetComponent<RectTransform>();

            RectTransform rt = itemBeingDraged.GetComponent<RectTransform>();

            rt.sizeDelta = new Vector2(tmpRT.sizeDelta.x, tmpRT.sizeDelta.y);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
            tmInfo = GetComponent<ItemInfo>();
            Transform canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
            itemBeingDraged.transform.SetParent(canvas);
            itemBeingDraged.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        itemBeingDraged.transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(itemBeingDraged);
        itemBeingDraged = null;
    }

    #endregion
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject slot = ReodenamientoDrop.slots[ReodenamientoDrop.slots.Count-1];
        if (slot.GetComponent<ItemInfo>().itemId == 0 && BotonChange.EsPlay == true)
        {
            GameObject duplicate = Instantiate(gameObject);
            itemBeingDraged = duplicate;

            tmInfo = itemBeingDraged.GetComponent<ItemInfo>();
            dropInfo = slot.GetComponent<ItemInfo>();

            Image tempSprite = itemBeingDraged.GetComponent<Image>();
            slot.GetComponent<Image>().sprite = tempSprite.sprite;

            dropInfo.itemId = tmInfo.itemId;
            dropInfo.name = tmInfo.name;

            Destroy(itemBeingDraged);
            itemBeingDraged = null;

            DropItem.cantItems++;
            while (ReodenamientoDrop.estaOrden() == false)
            {
                ReodenamientoDrop.reordenar();
            }
        }
    }
    public void Update()
    {
       /* if (Input.touchCount != 1)
        {
            isDrag = false;
            return;
        }*/
    }
}
